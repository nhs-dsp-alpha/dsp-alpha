// <copyright file="UserBlobService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Container.Model
{
    using Api.Container.Model.ClientSettings;
    using Api.Container.Model.Helpers;
    using Api.Container.Model.Interfaces;
    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class UserBlobService : IUserBlobService
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly ContainerSettings containerSettings;
        private readonly ILogger<UserBlobService> logger;

        public UserBlobService(
                ILogger<UserBlobService> logger,
                BlobServiceClient blobServiceClient,
                IOptions<ContainerSettings> settings)
        {
            this.blobServiceClient = blobServiceClient;
            this.containerSettings = settings.Value;
            this.logger = logger;
        }

        public virtual async Task<string> putProfilePicture(string userId, string ImageUrl)
        {
            try
            {
                string base64Image = ImageHelper.RemoveUrl(ImageUrl);

                var containerClient = this.blobServiceClient.GetBlobContainerClient(userId);
                bool isExist = containerClient.Exists();
                if (!isExist)
                {
                    containerClient.Create();
                }

                string blobName =
                    $"ProfilePicture{ImageHelper.GetFileExtensionString(base64Image)}";
                // string blobName = $"ProfilePicture";

                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                byte[] bytes = Convert.FromBase64String(base64Image);
                Stream stream = new MemoryStream(bytes);

                var blob = await blobClient.UploadAsync(stream,
                    new BlobHttpHeaders {ContentType = ImageHelper.GetMimeType(base64Image) });
                stream.Close();

                string blobUrl = @$"{this.blobServiceClient.Uri}{userId}/{blobName}";
                return blobUrl;

            }
            catch (Exception e)
            {
                this.logger.LogError(e.ToString());
                return string.Empty;
            }
        }
    }
}