// <copyright file="RouteMapping.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace BFF.Extensions
{
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using Microsoft.Identity.Web;
    using Constants = DigitalStaffPassport.Constants;
    using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;

    public static class RouteMapping
    {
        public static WebApplication MapRoutes<TUser, TClient>(this WebApplication app, bool useMicrosoftIdentity = false)
        {
            app.MapGet(
            "/Config",
            (HttpContext context, [FromServices] IOptionsMonitor<TClient> options) =>
            {
                return options.CurrentValue;
            }).WithName("GetConfig");

            return app.MapRoutes<TUser>(useMicrosoftIdentity: useMicrosoftIdentity);
        }

        public static WebApplication MapRoutes<TUser>(this WebApplication app, bool useMicrosoftIdentity = false)
        {
            app.MapGet("/Login", (HttpContext context) =>
            {
                if (useMicrosoftIdentity)
                {
                    return Results.LocalRedirect("/MicrosoftIdentity/Account/SignIn");
                }
                else
                {
                    var returnUrl = context.Request.Query[Constants.RequestParameters.RedirectUri].FirstOrDefault();

                    if (!context.User?.Identity?.IsAuthenticated == true)
                    {
                        var properties = new AuthenticationProperties { RedirectUri = returnUrl ?? "/", };
                        return Results.Challenge(properties);
                    }
                    else
                    {
                        return Results.Ok();
                    }
                }
            }).AllowAnonymous();

            app.MapGet("/Logout", (HttpContext context) =>
            {
                var returnUrl = context.Request.Query[Constants.RequestParameters.RedirectUri].FirstOrDefault("/");

                if (false && useMicrosoftIdentity)
                {
                    return Results.LocalRedirect($"/MicrosoftIdentity/Account/SignOut?returnUrl={returnUrl}");
                }
                else
                {
                    return Results.SignOut(new AuthenticationProperties { RedirectUri = returnUrl }, new string[] { CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme });
                }
            });

            app.MapGet(
            "/User",
            [AuthorizeForScopes(Scopes = new string[] { Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectScope.OpenIdProfile })]
            async (HttpContext context, [FromServices] ITokenAcquisition? tokenAcquisition, [FromServices] IConfiguration configuration) =>
            {
                var scopesToAccessDownstreamApi = configuration["ApiScopes"].Split(",");

                var accessToken = default(string);

                try
                {
                    accessToken = (tokenAcquisition != null) ?
                    await tokenAcquisition.GetAccessTokenForUserAsync(scopesToAccessDownstreamApi)
                    : await context.GetUserAccessTokenAsync();
                }
                catch (Exception)
                {
                }

                if (string.IsNullOrEmpty(accessToken))
                {
                    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return default;
                }
                else
                {
                    var payload = new JwtPayload(context.User?.Claims);
                    var json = payload.SerializeToJson();
                    var user = System.Text.Json.JsonSerializer.Deserialize<TUser>(json, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return user;
                }
            }).WithName("GetUser").RequireAuthorization(Constants.RequireAuthenticatedUserPolicy);

            app.MapFallbackToFile("index.html");

            return app;
        }
    }
}