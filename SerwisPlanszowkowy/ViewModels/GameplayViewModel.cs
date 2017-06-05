using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Model;

namespace SerwisPlanszowkowy.ViewModels
{
    public class GameplayViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Game")]
        public string GameName { get; set; }

        [Display(Name = "User")]
        public string UserName { get; set; }

         [Display(Name = "Game")]
        public int GameId { get; set; }

  
       
    }
}