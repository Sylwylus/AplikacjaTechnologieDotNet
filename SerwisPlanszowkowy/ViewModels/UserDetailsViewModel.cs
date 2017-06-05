using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerwisPlanszowkowy.ViewModels
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; }
      
      
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

      
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public bool Moderator { get; set; }

        public bool Administrator { get; set; }
      
         [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Date of bith")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }


        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Gameplay> Gameplays { get; set; }

    }
}