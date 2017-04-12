using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using WebUI.App_Start;
using WebUI.Helpers;

namespace WebUI.Attributes
{
    public class ValidateUserAttribute : ValidationAttribute
    {
        private string Email;
        private string Password;
        public string UserDisabledErrorMessage { get; set; }

        public ValidateUserAttribute(string email, string password)
        {
            if (email == null || password == null)
            {
                throw new ArgumentNullException();
            }

            Email = email;
            Password = password;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo tokenPropertyInfo = validationContext.ObjectType.GetProperty(Email);
            object tokenPropertyValue = tokenPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            PropertyInfo passwordPropertyInfo = validationContext.ObjectType.GetProperty(Password);
            object passwordPropertyValue = passwordPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (tokenPropertyValue == null | passwordPropertyValue == null)
            {
                return new ValidationResult(this.ErrorMessage);
            }

            var user = NinjectWebCommon.Get<IUserHelper>().GetUserByEmail(tokenPropertyValue.ToString());

            if (user == null)
            {
                return new ValidationResult(this.ErrorMessage);
            }

            var passHash = PasswordHelper.GetPasswordHash(passwordPropertyValue.ToString());

            var isUserValid = passHash.Equals(user.Password);

            return isUserValid ? null : new ValidationResult(this.ErrorMessage);
        }
    }
}