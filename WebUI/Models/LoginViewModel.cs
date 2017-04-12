using System.ComponentModel.DataAnnotations;
using WebUI.Attributes;

namespace WebUI.Models
{
    public class LoginViewModel
    {
        private const string EmailErrorMessage = "Пожалуйста введите свой почтовый адрес";
        private const string PasswordErrorMessage = "Пожалуйста введите пароль";
        private const string ValidateUserErrorMessage = "Неправильный почтовый адрес или пароль";

        [Required(ErrorMessage = EmailErrorMessage)]
        [EmailAddress(ErrorMessage =  EmailErrorMessage)]
        public string Email { get; set; }
        [Required(ErrorMessage = PasswordErrorMessage)]
        [DataType(DataType.Password)]
        [ValidateUser(nameof(Email), nameof(Password), ErrorMessage = ValidateUserErrorMessage)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}