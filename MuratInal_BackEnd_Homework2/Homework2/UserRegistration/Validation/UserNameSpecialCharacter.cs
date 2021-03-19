using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.RequestModel;

namespace UserRegistration.Validation
{
    public class UserNameSpecialCharacter : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            UserRequest request = (UserRequest)validationContext.ObjectInstance;
            var result = request.UserName.ToLower();

            if (result.Contains("ü") || result.Contains("ç") || result.Contains("ğ") || result.Contains("ı") || result.Contains("ş") || result.Contains("ö"))
            {
                return new ValidationResult(FormatErrorMessage("User name address cannot have special characters!"));
            }

            return ValidationResult.Success;
        }
    }
}
