using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerwisPlanszowkowy.Models
{
    public class ChartModel
    {
        public string Date { get; set; }
        public int Count { get; set; }
    }

    public class ChartModelUser
    {
        public string UserName { get; set; }
        public int Count { get; set; }
    }

    public class ChartModelUser2
    {
        public string UserName { get; set; }
        public int CountReviews { get; set; }
        public int CountComments { get; set; }
        public int CountRates { get; set; }
        public int Count { get; set; }
    }
}