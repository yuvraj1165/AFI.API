using AFI.API.Models;
using System.ComponentModel.DataAnnotations;

namespace AFI.API.ValidationAttributes
{
    public class CustomerIsAtLeast18YearsOldAtRegistration : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = ((CustomerRegistrationDTO)validationContext.ObjectInstance);

            if (customer.DOB.HasValue && customer.DOB.Value.AddYears(18) > System.DateTime.Today)
            {
                return new ValidationResult("The customer must be at least 18 years old at the time of registration",
                    new[] { nameof(CustomerRegistrationDTO) });
            }

            return ValidationResult.Success;
        }
    }
}