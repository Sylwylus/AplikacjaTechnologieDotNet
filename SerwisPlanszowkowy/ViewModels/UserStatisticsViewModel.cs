using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerwisPlanszowkowy.ViewModels
{
    public class UserStatisticsViewModel
    {
        public int Id { get; set; }

          [Display(Name = "Number of added reviews")]
        public int NumberOfAddedReviews { get; set; }
          [Display(Name = "Number of added comments")]
        public int NumberOfAddedComments { get; set; }
          [Display(Name = "Number of added rates")]
        public int NumberOfAddedRates { get; set; }
          [Display(Name = "Number of added gameplays")]
        public int NumberOfAddedGameplays { get; set; }
          public virtual ICollection<RateViewModel> Rates { get; set; }
          [Display(Name = "Avarage of added rates")]
          public float AvarageOfAddedRates
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

                  return avarage;
              }
          }
    }
    
}