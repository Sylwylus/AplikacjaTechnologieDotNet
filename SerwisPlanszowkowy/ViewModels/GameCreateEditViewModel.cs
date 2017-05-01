using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using SerwisPlanszowkowy.ValidationAttributes;

namespace SerwisPlanszowkowy.ViewModels
{
    public class GameCreateEditViewModel
    {
        public int Id { get; set; }
         [Required(ErrorMessage = "Name is required")]
         [MaxLength(30, ErrorMessage = "Name cannot contain more than 30 characters")]
        public string Name { get; set; }
        [Display(Name = "Published date")]
        [Required(ErrorMessage = "Published date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }
         [Required(ErrorMessage = "Publisher is required")]
         [MaxLength(30, ErrorMessage = "Publisher cannot contain more than 300 characters")]
        public string Publisher { get; set; }
         [Required(ErrorMessage = "Publisher is required")]
        [Range(1, 1000, ErrorMessage = "Playing time should be greater than 0 and less than 1000 min")]
        [Display(Name = "Playing time (in minutes)")]
        public int PlayingTime { get; set; }
         [Required(ErrorMessage = "Min number of players is required")]
        [Range(1,10, ErrorMessage = "Min number of players should be greater than 0 and less than 10")]
        [Display(Name = "Min players")]
        public int MinNumberOfPlayers { get; set; }
        [Display(Name = "Max players")]
        [Required(ErrorMessage = "Max number of players is required")]
        [Range(1, 100, ErrorMessage = "Min number of players should be greater than 0 and less than 100")]
    //    [GreaterThanOrEqualTo("MinNumberOfPlayers" , ErrorMessage = "Max number of players should be greater or equal to min number of players")]
        public int MaxNumberOfPlayers { get; set; }
        [Display(Name = "Suggested age")]
        [Required(ErrorMessage = "Suggested age is required")]
        [Range(3, 200, ErrorMessage = "Suggested age should be greater than 2 and less than 200")]
        public int SuggestedAge { get; set; }
        [MaxLength(300, ErrorMessage = "Description cannot contain more than 300 characters")]
        [MinLength(50, ErrorMessage = "Description cannot contain less than 50 characters")]
        [Required(ErrorMessage = "Description is required")]
        public String Description { get; set; }
        public byte[] Photo { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public string CategoryId { get; set; }
        public bool Accepted { get; set; }
        public byte[] OldPhoto { get; set; }
   
        public String PhotoSource
        {
           
        get
        {
            if (Photo != null)
            {
                return ("data:image/png;base64," + Convert.ToBase64String(Photo));
            }
            else
            {
                return null;
            }
        }
    
    }
     
    }
}