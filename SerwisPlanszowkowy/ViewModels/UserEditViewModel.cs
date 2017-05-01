using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SerwisPlanszowkowy.ValidationAttributes;

namespace SerwisPlanszowkowy.ViewModels
{
    public class UserEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of bith")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }
    }
}