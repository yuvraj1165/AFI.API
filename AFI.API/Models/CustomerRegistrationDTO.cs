using AFI.API.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace AFI.API.Models
{
    /// <summary>
    /// An Animal Friends Insurance customer with FirstName, LastName, PolicyNo, DOB and EmailAddress
    /// </summary>
    [CustomerIsAtLeast18YearsOldAtRegistration]
    public class CustomerRegistrationDTO
    {   /// <summary>
        /// Policy holders first name
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Policy holders first name must be between 3 and 50 characters in length")]
        public string PolicyHolderFirstName { get; set; }

        /// <summary>
        /// Policy holders last name
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Policy holders last name must be between 3 and 50 characters in length")]
        public string PolicyHolderLastName { get; set; }

        /// <summary>
        /// Policy holders insurance policy number
        /// </summary>
        [Required]
        [RegularExpression("^[A-Z]{2}-[0-9]{6}$", ErrorMessage = "Policy number must match the format XX-999999. Where XX are any capitalised alpha character followed by a hyphen and 6 numbers")]
        public string PolicyReferenceNumber { get; set; }

        /// <summary>
        /// Policy holders date of birth
        /// </summary>
        public DateTime? DOB { get; set; }

        /// <summary>
        /// Policy holders email address
        /// </summary>
        [RegularExpression("^\\w{4,}@\\w{2,}(\\.com|\\.co\\.uk)$", ErrorMessage = "Policy holders email address should contain a string of at least 4 alpha numeric chars followed by an '@' sign and then another string of at least 2 alpha numeric chars. The email address should end in either '.com' or '.co.uk'")]
        public string? PolicyHolderEmail { get; set; }
    }
}