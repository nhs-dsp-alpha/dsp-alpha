// <copyright file="NHSEOFields.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credentials.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class NHSEOFields
    {
        public string? CredentialSerialNumber { get; set; }

        [Required(ErrorMessage = "Preferred First Name is required")]
        public string? PreferredFirstName { get; set; }

        [Required(ErrorMessage = "Preferred Surname is required")]
        public string? PreferredSurname { get; set; }

        [Required(ErrorMessage = "Legal First is required")]
        public string? LegalFirstName { get; set; }

        [Required(ErrorMessage = "Legal Surname is required")]
        public string? LegalSurname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        [Required(ErrorMessage = "Please enter your date of birth")]
        public string? DateOfBirth { get; set; }

        [Required(ErrorMessage = "National Insurance Number is required")]
        public string? NationalInsuranceNumber { get; set; }

        [Required(ErrorMessage = "Work Email is required")]
        public string? WorkEmail { get; set; }

        [JsonPropertyName("esrId")]
        public string? ESRNumber { get; set; }

        [JsonPropertyName("smartcardNumber")]
        public string? SmartcardNumberUUID { get; set; }

        [JsonPropertyName("dbsLevel")]
        public string? DBSLevel { get; set; }

        [JsonPropertyName("dbsReferenceNumber")]
        public string? DBSReferenceNumber { get; set; }

        [JsonPropertyName("dbsUpdateService")]
        public string? DBSUpdateService { get; set; }

        [JsonPropertyName("dbsBarredListAdult")]
        public string? DBSBarredListAdult { get; set; }

        [JsonPropertyName("dbsBarredListChildren")]
        public string? DBSBarredListChildren { get; set; }

        public string? RightToWorkResidencyStatus { get; set; }

        public string? RightToWorkVisaType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        public string? RightToWorkExpiryDate { get; set; }

        public string? ProfessionalRegistrationBody { get; set; }

        public string? ProfessionalRegistrationNumber { get; set; }

        public string? OccupationalHealthClearanceStatus { get; set; }

        public string? OccupationalHealthServiceContactNumber { get; set; }

        public string? OccupationalHealthServiceEmailAddress { get; set; }

        public string? EmployingOrganisationFullName { get; set; }

        [JsonPropertyName("employingOrganisationODS")]
        public string? EmployingOrganisationODS { get; set; }

        public string? JobTitle { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        public string? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        public string? EndDate { get; set; }

        public string? Department { get; set; }

        public string? StaffGroup { get; set; }

        public string? JobRole { get; set; }

        [JsonPropertyName("payBandAfC")]
        public string? PayBandAfC { get; set; }

        public string? AreaOfWork { get; set; }

        [JsonPropertyName("occupationalCode")]
        public string? OccupationCode { get; set; }

        public string? WorkingTimeDirectiveOptOut { get; set; }

        public string? Error { get; set; }
    }
}