using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Model;

namespace SerwisPlanszowkowy.ViewModels
{
    public class GameDetailsViewModel
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
        
        public String Description { get; set; }
        public byte[] Photo { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public bool Accepted { get; set; }


        public String PhotoSource
        {
            get { return ("data:image/png;base64," + Convert.ToBase64String(Photo)); }
        }



        public virtual ICollection<RateViewModel> Rates { get; set; }   
        public virtual ICollection<CommentViewModel> Comments { get; set; }

        [Display(Name = "Avarage Rate")]
        public float AvarageRate
        {
            get
            {
                float suma = 0;
                foreach (var r in Rates)
                {
                    suma += r.Value;
                }
                float avarage = 0;
                if (Rates.Count() != 0)
                {
                    avarage = suma / Rates.Count();
                }

                avarage = (float)Math.Round(avarage, 2);
                return avarage;
            }
        }

    }
}