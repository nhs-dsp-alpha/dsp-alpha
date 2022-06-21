// <copyright file="HttpClientParRequestExtensions.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credential.Extensions
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Credential.Extensions.Model;
    using IdentityModel;
    using IdentityModel.Client;

    /// <summary>
    /// HttpClient extensions for Pushed Authorization requests.
    /// </summary>
    public static class HttpClientParRequestExtensions
    {
        /// <summary>
        /// Sends a Pushed Authorization request using the client_credentials grant type.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The Pushed Authorization  Response.</returns>
        public static async Task<ParResponse?> RequestPushedAuthorizationAsync(this HttpMessageInvoker client, PushedAuthorizationRequest request, CancellationToken cancellationToken = default)
        {
            var clone = request.Clone();

            clone.Parameters.AddRequired(OidcConstants.TokenRequest.Scope, request.Scope);
            clone.Parameters.AddRequired(OidcConstants.AuthorizeRequest.IdTokenHint, request.IdTokenHint);
            clone.Parameters.AddRequired(OidcConstants.AuthorizeRequest.RedirectUri, request.RedirectUri);
            clone.Parameters.AddRequired(OidcConstants.AuthorizeRequest.Nonce, request.Nonce);
            clone.Parameters.AddRequired(OidcConstants.AuthorizeRequest.State, request.State);

            return await client.RequestParAsync(clone, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a Pushed Authorization request.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="address">The address.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The Pushed Authorization response.</returns>
        /// <exception cref="ArgumentNullException">parameters.</exception>
        public static async Task<ParResponse?> RequestParRawAsync(this HttpMessageInvoker client, string address, Parameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var request = new PushedAuthorizationRequest
            {
                Address = address,
                Parameters = parameters,
            };

            return await client.RequestParAsync(request, cancellationToken).ConfigureAwait(false);
        }

        internal static async Task<ParResponse?> RequestParAsync(this HttpMessageInvoker client, ProtocolRequest request, CancellationToken cancellationToken = default)
        {
            request.Prepare();
            request.Method = HttpMethod.Post;

            HttpResponseMessage response;

            response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ParResponse>();
        }
    }
}