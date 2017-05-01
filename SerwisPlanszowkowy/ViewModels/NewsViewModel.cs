using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Model;

namespace SerwisPlanszowkowy.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Published Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name = "User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
