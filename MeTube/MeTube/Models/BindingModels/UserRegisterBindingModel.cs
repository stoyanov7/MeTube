namespace MeTube.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using Utilities;

    public class UserRegisterBindingModel
    {
        [Required]
        [MinLength(3)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(
            PasswordConfiguration.MaxLength,
            ErrorMessage = PasswordConfiguration.ErrorMessage, 
            MinimumLength = PasswordConfiguration.MinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = PasswordConfiguration.ConfirmationMessage)]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
