// <copyright file="WebApplicationBuilderExtensions.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace BFF.Extensions
{
    using Azure.Identity;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Configuration.AzureAppConfiguration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Identity.Web.UI;
    using System.Text.Json.Serialization;

    public static class WebApplicationBuilderExtensions
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public static WebApplication BuildOAuthBFF(this WebApplicationBuilder builder, IEnumerable<string>? extraConfigurationLabel = default)
        {
            builder.AddBFFCommonServices(extraConfigurationLabel);
            builder.Services.AddOauthBFF(builder.Configuration);
            return builder.AddBFFCore();
        }

        public static WebApplication BuildOidcBFF<T>(this WebApplicationBuilder builder, IEnumerable<string>? extraConfigurationLabel = default)
        {
            builder.AddBFFCommonServices(extraConfigurationLabel);
            builder.Services.AddOidcBFF(builder.Configuration);
            return builder.AddBFFCore();
        }

        public static WebApplication BuildB2CBFF(this WebApplicationBuilder builder, IEnumerable<string>? extraConfigurationLabel = default)
        {
            builder.AddBFFCommonServices(extraConfigurationLabel);
            builder.Services.AddB2CBFF(builder.Configuration)
                .AddControllers()
            .AddMicrosoftIdentityUI();

            builder.Services.AddRazorPages();

            return builder.AddBFFCore();
        }

        public static WebApplicationBuilder AddBFFCommonServices(this WebApplicationBuilder builder, IEnumerable<string>? extraConfigurationLabel = default, bool useStaticFiles = true)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy(
                        name: MyAllowSpecificOrigins,
                        corsBuilder =>
                        {
                            corsBuilder.WithOrigins("https://localhost:44469").AllowCredentials().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("Location");
                            corsBuilder.WithOrigins("https://localhost:44432").AllowCredentials().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("Location");
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

            builder.Configuration.AddAzureAppConfiguration(options =>
            {
                var credential = new DefaultAzureCredential();

                options.Connect(new Uri(connectionString), credential)

                    .ConfigureKeyVault(kv => kv.SetCredential(credential))

                    // Load configuration values with no label
                    .Select(KeyFilter.Any, LabelFilter.Null)

                    // Load configuration values with no label
                    .Select(KeyFilter.Any, "BFF")

                    // Override with any configuration values specific to current hosting env
                    .Select(KeyFilter.Any, builder.Environment.EnvironmentName);

                if (builder.Environment.IsDevelopment())
                {
                    options.Select(KeyFilter.Any, "BFF-DEV");
                }

                if (extraConfigurationLabel != default)
                {
                    foreach (var label in extraConfigurationLabel)
                    {
                        options.Select(KeyFilter.Any, label);
                    }
                }
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        internal static WebApplication AddBFFCore(this WebApplicationBuilder builder, bool useStaticFiles = true)
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

            if (useStaticFiles)
            {
                app.UseStaticFiles();
            }

            // Enable routing middleware in pipeline
            app.UseRouting();

            if (app.Environment.IsDevelopment())
            {
                app.UseCors(MyAllowSpecificOrigins);
            }

            // Enable authentication middleware in pipeline
            app.UseAuthentication();

            // Enable routing middleware in pipeline
            app.UseAuthorization();

            // Enable YARP reverse proxy middleware in pipeline
            app.MapReverseProxy();

            return app;
        }
    }
}