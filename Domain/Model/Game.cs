using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Game 
    {
       
        public int Id { get; set; }
  
        public string Name { get; set; }

        public DateTime PublishedDate { get; set; }
        public string Publisher { get; set; }
        public int PlayingTime { get; set; }
        public int MinNumberOfPlayers { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int SuggestedAge { get; set; }

        public String Description { get; set; }
        public byte[] Photo { get; set; }
        public bool Accepted { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
