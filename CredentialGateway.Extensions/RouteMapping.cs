// <copyright file="RouteMapping.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace CredentialGateway.Extensions
{
    using System.IdentityModel.Tokens.Jwt;
    using Api.Services;
    using DigitalStaffPassport;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;

    internal static class RouteMapping
    {
        public static WebApplication MapCredentialGatewayRoutes(this WebApplication app)
        {
            app.MapGet("/Processing", (HttpContext context) =>
            {
                var status = "processing...";
                var detail = "processing...<br /> <a href='javascript:window.close()'>Close</a>";
                var script = @"window.close();";

                return Results.Content($"<h1>{status}</h1><p>{detail}</p><script>{script}</script>", "text/html");
            })
            .AllowAnonymous()
            .ExcludeFromDescription();

            app.MapGet("/Error", (HttpContext context) =>
            {
                var status = "An error occurred.";
                var detail = "<a href='javascript:window.close()'>Close</a>";

                return Results.Content($"<h1>{status}</h1><p>{detail}</p>", "text/html");
            })
            .AllowAnonymous()
            .ExcludeFromDescription();

            app.MapGet("/Issue", async (HttpContext context) =>
            {
                var credentialType = "PrimaryIdentityCredential";
                var credentialIssuer = "PostOffice";

                var returnUrl = context.Request.Query[Constants.RequestParameters.RedirectUri].FirstOrDefault();

                var items = new Dictionary<string, string?> { { "credentialType", credentialType }, { "credentialIssuer", credentialIssuer } };

                var properties = new AuthenticationProperties(items) { RedirectUri = returnUrl ?? "/Processing" };

                await context.ChallengeAsync("CredentialGateway", properties);
            }).WithName("Issue").AllowAnonymous();

            app.MapGet("/Issued", async (HttpContext context) =>
            {
                var payload = default(JwtPayload);

                var props = await context.AuthenticateAsync("CredentialGateway");
                if (props.Succeeded)
                {
                    payload = new JwtPayload(props.Principal.Claims.ToArray());
                }

                return payload;
            })
            .AllowAnonymous();

            app.MapGet("/Verify/{credentialType}/{credentialIssuer}", async (HttpContext context, string credentialType, string credentialIssuer, IClientService portalService) =>
            {
                if (credentialType == string.Empty) { credentialType = "PrimaryIdentityCredential"; }
                if (credentialIssuer == string.Empty) { credentialIssuer = "PostOffice"; }

                var returnUrl = context.Request.Query[Constants.RequestParameters.RedirectUri].FirstOrDefault();

                var items = new Dictionary<string, string?> { { "credentialType", credentialType }, { "credentialIssuer", credentialIssuer } };

                var properties = new AuthenticationProperties(items) { RedirectUri = returnUrl ?? "/Processing" };

                await context.ChallengeAsync("CredentialVerify", properties);
            }).WithName("Verify").AllowAnonymous();

            app.MapGet("/Verified", async (HttpContext context) =>
            {
                var payload = default(JwtPayload);

                var props = await context.AuthenticateAsync("CredentialVerify");
                if (props.Succeeded)
                {
                    payload = new JwtPayload(props.Principal.Claims.ToArray());
                }

                return payload;
            })
            .AllowAnonymous();

            return app;
        }
    }
}