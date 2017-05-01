using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Model;

namespace SerwisPlanszowkowy.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }
        public string Content { get; set; }
        [Display(Name = "Game")]
        public int GameId { get; set; }
        [Display(Name = "User")]
        public int UserId { get; set; }

        public virtual GameViewModel Game { get; set; }
        public virtual User User { get; set; }
    }
}