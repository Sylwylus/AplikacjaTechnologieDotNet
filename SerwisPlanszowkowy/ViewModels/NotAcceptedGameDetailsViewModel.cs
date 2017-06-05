using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerwisPlanszowkowy.ViewModels
{
    public class NotAcceptedGameDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Published Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }
        public string Publisher { get; set; }
        [Display(Name = "Playing Time")]
        public int PlayingTime { get; set; }
        [Display(Name = "Min Players")]
        public int MinNumberOfPlayers { get; set; }
        [Display(Name = "Max Players")]
        public int MaxNumberOfPlayers { get; set; }
        [Display(Name = "Suggested Age")]
        public int SuggestedAge { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public String Description { get; set; }
        public byte[] Photo { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public bool Accepted { get; set; }
        public bool Delete { get; set; }

        public String PhotoSource
        {
            get { return ("data:image/png;base64," + Convert.ToBase64String(Photo)); }
        }


    }
}