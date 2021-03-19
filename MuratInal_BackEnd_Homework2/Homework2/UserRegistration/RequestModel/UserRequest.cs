using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Validation;

namespace UserRegistration.RequestModel
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Id area must be filled!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "User name area must be filled!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Name area must be filled!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname area must be filled!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "E-Mail area must be filled!")]
        public string UserMail { get; set; }
        [Required(ErrorMessage = "Password area must be filled!")]
        // [StringLength(30, MinimumLength = 5)]
        public string Password { get; set; }


        public (bool isNotValid, List<string> errors) Validate()
        {
            List<string> errorList = new List<string>();

            if (Password.Length >= 30 || Password.Length < 5)
            {
                errorList.Add("Password length must be between 5 and 30 characters!");
            }

            if (UserMail.Contains("ü") || UserMail.Contains("ç") || UserMail.Contains("ğ") || UserMail.Contains("ı") || UserMail.Contains("ş") || UserMail.Contains("ö"))
            {
                errorList.Add("E-Mail address cannot have special characters!");
            }

            if (UserName.Contains("ü") || UserName.Contains("ç") || UserName.Contains("ğ") || UserName.Contains("ı") || UserName.Contains("ş") || UserName.Contains("ö"))
            {
                errorList.Add("User Name address cannot have special characters!");
            }

            return (errorList.Count > 0, errorList);
        }
    }
}
