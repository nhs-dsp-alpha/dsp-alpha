// <copyright file="UserManagerService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.MsGraph.Services
{
    using Api.MsGraph.Services.ClientSettings;
    using Api.MsGraph.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using Microsoft.Graph;

    public class UserManagerService : IUserManagerService
    {
        private readonly GraphServiceClient graphClient;
        private readonly B2CUserSettings userSettings;

        public UserManagerService(
            GraphServiceClient graphClient,
            IOptions<B2CUserSettings> settings)
        {
            this.graphClient = graphClient;
            this.userSettings = settings.Value;
        }

        public virtual async Task<string> GetUserPhoto(string userId)
        {
            Helpers.B2cCustomAttributeHelper helper = new Helpers.B2cCustomAttributeHelper(this.userSettings.B2cExtensionAppClientId);
            string photoAttribute = helper.GetCompleteAttributeName("Photo");

            var select = $"{photoAttribute}";
            User user = await this.graphClient.Users[userId].Request().Select(select).GetAsync();

            return this.GetUserAttribute(user, photoAttribute);
        }

        public virtual async Task<string> PutUserPhoto(string userId, string base64ImageString)
        {
            Helpers.B2cCustomAttributeHelper helper = new Helpers.B2cCustomAttributeHelper(this.userSettings.B2cExtensionAppClientId);

            string attributeName = helper.GetCompleteAttributeName("Photo");

            var select = $"id, givenName, surName, {attributeName}";
            var user = await this.graphClient.Users[userId].Request().Select(select).GetAsync();

            IDictionary<string, object> extensionInstance = new Dictionary<string, object>();
            extensionInstance.Add(attributeName, base64ImageString);

            User updatedUser = new User()
            {
                AdditionalData = extensionInstance,
            };

            await this.graphClient.Users[userId].Request().UpdateAsync(updatedUser);

            return base64ImageString;
        }

        private string GetUserAttribute(User user, string attributeName)
        {
            object value;
            if (user.AdditionalData.TryGetValue(attributeName, out value))
            {
                return (string)value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}