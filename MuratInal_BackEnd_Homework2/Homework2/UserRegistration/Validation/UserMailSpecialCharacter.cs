using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.RequestModel;

namespace UserRegistration.Validation
{
    public class UserMailSpecialCharacter : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            UserRequest request = (UserRequest)validationContext.ObjectInstance;
            var mail = request.UserMail.ToLower();
            if (mail.Contains("ü") || mail.Contains("ç") || mail.Contains("ğ") || mail.Contains("ı") || mail.Contains("ş") || mail.Contains("ö"))
            {
                return new ValidationResult(FormatErrorMessage("E - Mail address cannot have special characters!"));
            }

            return ValidationResult.Success;
        }
    }
}
