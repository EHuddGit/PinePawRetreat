using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Services.Description;

namespace PinePawRetreat.Models
{


    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"^[A-Za-z'-]+$", ErrorMessage = "First name has invalid characters")]
        [StringLength(100,MinimumLength = 1, ErrorMessage = "First Name must be inbetween 1 and 100 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z'-]+$", ErrorMessage = "Last name has invalid characters")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Last Name must be inbetween 1 and 100 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Phone Number Required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //should eventually add an address 2 field
        [Display(Name = "Address")]
        [StringLength(100, MinimumLength = 2,ErrorMessage = "Address is required to be between 2 and 100 characters")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Address is required to be between 2 and 100 characters")]
        public string City { get; set; }

        [Display(Name = "State")]
        [StringLength(2)]
        [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "Use 2-letter state code (e.g., OR).")]
        public string State { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
