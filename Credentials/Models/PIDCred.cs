// <copyright file="PIDCred.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credentials.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class PIDCred
    {
        public string? DocumentType { get; set; }

        [Required(ErrorMessage = "Document Number is required")]
        public string? DocumentNumber { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Given Names is required")]
        public string? GivenNames { get; set; }

        [Required(ErrorMessage = "Nationality is required")]
        public string? Nationality { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        [Required(ErrorMessage = "Please enter your date of birth")]
        public string? DateOfBirth { get; set; }

        public string? Sex { get; set; }

        [Required(ErrorMessage = "Place of Birth is required")]
        public string? PlaceOfBirth { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of Issue is required")]
        public string? DateOfIssue { get; set; }

        public string? IssuingAuthority { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of Expiry is required")]
        public string? DateOfExpiry { get; set; }

        public string? Photograph { get; set; } = string.Empty;

        public string? Signature { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Telephone { get; set; } = string.Empty;

        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        ////[Required(ErrorMessage = "Please choose image to upload.")]
        public IFormFile? UploadPhotograph { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        ////[Required(ErrorMessage = "Please choose image to upload.")]
        public IFormFile? UploadSignature { get; set; }

        public string? Error { get; set; }
    }
}