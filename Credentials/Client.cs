// <copyright file="Client.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credentials
{
    using System.Collections.Generic;

    public class Client
    {
        public Client()
        {
            // this.Credentials = new List<string>();
        }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<string> Credentials { get; set; }
    }
}