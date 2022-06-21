// <copyright file="WebApplicationBuilderExtensions.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services.Extensions
{
    using System.Text.Json.Serialization;
    using Azure.Identity;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Configuration.AzureAppConfiguration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class WebApplicationBuilderExtensions
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public static WebApplicationBuilder AddApiCommonServices(this WebApplicationBuilder builder, IEnumerable<string>? labels = default)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy(
                        name: MyAllowSpecificOrigins,
                        corsBuilder =>
                        {
                            if (builder.Environment.IsDevelopment())
                            {
                                corsBuilder.AllowAnyOrigin();
                            }
                            else
                            {
                                corsBuilder.WithOrigins("https://bffdevapimanagement.azure-api.net");
                            }

                            corsBuilder.AllowAnyMethod().AllowAnyOrigin();
                        });
                });
            }

            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
            {
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

            // Retrieve the Connection String from the secrets manager
            var connectionString = builder.Configuration.GetConnectionString("AppConfig");

            if (!string.IsNullOrEmpty(connectionString))
            {
                builder.Configuration.AddAzureAppConfiguration(options =>
                {
                    var credential = new DefaultAzureCredential();

                    options.Connect(new Uri(connectionString), credential)

                        .ConfigureKeyVault(kv => kv.SetCredential(credential))

                        // Load configuration values with no label
                        .Select(KeyFilter.Any, LabelFilter.Null)

                        // Override with any configuration values specific to current hosting env
                        .Select(KeyFilter.Any, builder.Environment.EnvironmentName);

                    if (labels != null)
                    {
                        foreach (var label in labels)
                        {
                            options.Select(KeyFilter.Any, label);
                        }
                    }
                });
            }

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplication AddApiCore(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enable HSTS middleware in pipeline
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable https redirection middleware in pipeline
            app.UseHttpsRedirection();

            // Enable routing middleware in pipeline
            app.UseRouting();

            if (app.Environment.IsDevelopment())
            {
                app.UseCors(MyAllowSpecificOrigins);
            }

            // Enable authentication middleware in pipeline
            // app.UseAuthentication();

            // Enable routing middleware in pipeline
            app.UseAuthorization();

            return app;
        }
    }
}