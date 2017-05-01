using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class News 
    {
        public int Id { get; set; }  
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
