// <copyright file="ImageHelper.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Container.Model.Helpers
{
    using System.Drawing;

    public static class ImageHelper
    {
        public static string RemoveUrl(string base64String)
        {
            return base64String.Substring(base64String.IndexOf(",") + 1);
        }

        public static Image ConvertStringToImage(string base64String)
        {
            base64String = base64String.Substring(base64String.IndexOf(",") + 1);

            byte[] bytes = Convert.FromBase64String(base64String);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }

        public static string GetMimeType(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "image/png";
                case "/9J/4":
                    return "image/jpeg";
                case "0lGODdh":
                    return "image/gif";
                case "R0lGODlh":
                    return "image/gif";
            }

            return string.Empty;

        }

        public static string? GetFileExtensionString(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return ".png";
                case "/9J/4":
                    return ".jpeg";
                case "0lGODdh":
                    return ".gif";
                case "R0lGODlh":
                    return ".gif";
            }

            return null;

        }
    }
}
