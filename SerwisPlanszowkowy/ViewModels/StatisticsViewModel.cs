using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerwisPlanszowkowy.ViewModels
{
    public class StatisticsViewModel
    {
        public DotNet.Highcharts.Highcharts ReviewChart { get; set; }
        public DotNet.Highcharts.Highcharts UserChart { get; set; }
        public DotNet.Highcharts.Highcharts GameChart { get; set; }
        public DotNet.Highcharts.Highcharts CommentChart { get; set; }
        public DotNet.Highcharts.Highcharts RateChart { get; set; }
        public DotNet.Highcharts.Highcharts NewsChart { get; set; }
        public DotNet.Highcharts.Highcharts ActiveUsersChart { get; set; }
        public DotNet.Highcharts.Highcharts ActiveModeratorsChart { get; set; }
        public DotNet.Highcharts.Highcharts ReviewMonthChart { get; set; }
        public DotNet.Highcharts.Highcharts GameMonthChart { get; set; }
        public DotNet.Highcharts.Highcharts RateMonthChart { get; set; }
        public DotNet.Highcharts.Highcharts CommentMonthChart { get; set; }
        public DotNet.Highcharts.Highcharts UserMonthChart { get; set; }
        public DotNet.Highcharts.Highcharts NewsMonthChart { get; set; }
    }
}