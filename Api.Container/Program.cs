#pragma warning disable SA1200 // Using directives should be placed correctly
using Api.Container.Model;
using Api.Container.Model.ClientSettings;
using Api.Container.Model.Interfaces;
using Api.Services.Extensions;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Azure;
using Microsoft.Identity.Web;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiCommonServices(new List<string> { "ContainerApi", "WebApi" });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"))
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddInMemoryTokenCaches();

builder.Services
    .AddAuthorization()
    .AddTransient<IUserBlobService, UserBlobService>()
    .Configure<ContainerSettings>(builder.Configuration.GetSection("Container"));

builder.Services.AddAzureClients(azureBuilder =>
{
    azureBuilder.AddBlobServiceClient(new Uri(builder.Configuration.GetSection("Container:ConnectionString").Value))
        .WithCredential(new DefaultAzureCredential());
});

var app = builder.AddApiCore()
    .MapContainerRoutes();

app.Run();