using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerwisPlanszowkowy.ViewModels
{
    public class RateViewModel
    {
        public int Id { get; set; }
        public int Value { get; set; }
        [Display(Name="Game")]
        public int GameId { get; set; }
        [Display(Name="User")]
        public int UserId { get; set; }
        
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}