using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerwisPlanszowkowy.ViewModels
{
    public class GameplayCreateEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Game")]
        public string GameName { get; set; }

        [Display(Name = "User")]
        public string UserName { get; set; }


        [Display(Name = "Game")]
        public int GameId { get; set; }

        public IEnumerable<GroupedSelectListItem> Games { get; set; }
    }
}