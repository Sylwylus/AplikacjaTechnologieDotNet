using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Rate 
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public DateTime PublishedDate { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
       
    }
}
