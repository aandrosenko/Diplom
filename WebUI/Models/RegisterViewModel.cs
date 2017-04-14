using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebUI.Attributes;
using WebUI.Properties;

namespace WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FirstNameErrorMessage")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "LastNameErrorMessage")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailErrorMessage")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailErrorMessage")]
        [Display(Name = "Е-мейл")]
        [UserExist(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "UserExistErrorMessage")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordErrorMessage")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ConfirmPasswordErrorMessage")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ComparePasswordErrorMessage")]
        [Display(Name = "Подтвердите пароль")]
        public string ConfirmPassword { get; set; }
    }
}