using System.ComponentModel.DataAnnotations;
using WebUI.Attributes;
using WebUI.Properties;

namespace WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailErrorMessage")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailErrorMessage")]
        [Display(Name="Е-мейл")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordErrorMessage")]
        [DataType(DataType.Password)]
        [ValidateUser(nameof(Email), nameof(Password), ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidateUserErrorMessage")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}