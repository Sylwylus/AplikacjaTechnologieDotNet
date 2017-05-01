using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Review 
    {
        public int Id { get; set; }
      
        public  DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Accepted { get; set; }
      
        public int GameId { get; set; }
    
        public int UserId { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
