// <copyright file="CredentialGatewayConfiguration.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credentials
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class CredentialGatewayConfiguration
    {
        private IDictionary<string, IEnumerable<Client>>? lookup = null;

        public CredentialGatewayConfiguration()
        {
        }

        public string? Authority { get; set; }

        [JsonIgnore]
        public IDictionary<string, IEnumerable<Client>> Lookup
        {
            get
            {
                if (this.lookup == null)
                {
                    if (this.Clients != null)
                    {
                        var lookup = this.Clients.SelectMany(client => client.Credentials.Select(cred => new KeyValuePair<string, Client>(cred, client)));
                        this.lookup = lookup.Select(l => l.Key).Distinct()
                            .ToDictionary(key => key, key => lookup.Where(l => l.Key == key).Select(l => l.Value));
                    }
                }

                return this.lookup;
            }
        }

        public IEnumerable<Client>? Clients { get; set; }
    }
}