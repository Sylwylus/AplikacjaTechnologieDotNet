using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerwisPlanszowkowy.ViewModels
{
    public class ManageUserViewModel
    {
        [Required(ErrorMessage = "old password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

       
        [Required(ErrorMessage = "new password is required")]
        [RegularExpression(@"^.*(?=.{4,10})(?=.*\d)(?=.*[a-zA-Z]).*$", ErrorMessage = "Password must contains at least one number")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}