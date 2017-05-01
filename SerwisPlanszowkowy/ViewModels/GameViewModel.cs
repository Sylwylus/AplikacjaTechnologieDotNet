using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Model;

namespace SerwisPlanszowkowy.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Publisher { get; set; }
      
       
       
        public byte[] Photo { get; set; }

        public String PhotoSource
        {
            get { return ("data:image/png;base64," + Convert.ToBase64String(Photo)); }
        }



        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public bool Accepted { get; set; }

        public virtual ICollection<RateViewModel> Rates { get; set; }

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