using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SerwisPlanszowkowy.ValidationAttributes;

namespace SerwisPlanszowkowy.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        [StringLength(15, ErrorMessage = "User name should contains maximum 15 characters.")]
        [Display(Name = "User name")]
        [UniqueUsername(ErrorMessage = "This user name already exists")]
        public string UserName { get; set; }

          [Required(ErrorMessage = "password is required")]
          [RegularExpression(@"^.*(?=.{4,10})(?=.*\d)(?=.*[a-zA-Z]).*$", ErrorMessage = "Password must contains at least one number")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

         [Required]
         [StringLength(15, ErrorMessage = "Fist name should contains maximum 15 characters.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

         [Required]
        [Display(Name = "Last name")]
        [StringLength(20, ErrorMessage = "Last name should contains maximum 20 characters.")]
        public string LastName { get; set; }

         [Required]
         [Display(Name = "E-mail")]
         [EmailAddress(ErrorMessage = "Wrong format of e-mail")]
        public string Email { get; set; }

         [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of bith")]
        public DateTime DateOfBirth { get; set; }
    }
}