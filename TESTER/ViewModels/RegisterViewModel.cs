using System.ComponentModel.DataAnnotations;

namespace TESTER.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Compare("ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
