namespace MeTube.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using Utilities;

    public class UserLoginBindingModel
    {
        [Required]
        [MinLength(3)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}