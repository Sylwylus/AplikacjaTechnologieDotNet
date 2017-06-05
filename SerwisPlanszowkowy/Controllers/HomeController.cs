using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain;
using Domain.Model;
using Data;
using SerwisPlanszowkowy.ViewModels;
using Application.Services;
using DotNet.Highcharts;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Enums;
using SerwisPlanszowkowy.Models;

namespace SerwisPlanszowkowy.Controllers
{
    public class HomeController : Controller
    {
        private INewsService _newsService { get; set; }
        private IGameService _gameService { get; set; }
        private IReviewService _reviewService { get; set; }
        private CrudContext _context { get; set; }
        public  HomeController(CrudContext context, INewsService newsService, IGameService gameService, IReviewService reviewService)
        {
            _newsService = newsService;
            _gameService = gameService;
            _reviewService = reviewService;
            _context = context;
        }
        public ActionResult Index()
        {
            var newses = _newsService.GetNews();
            var games = _gameService.GetAcceptedGames();
            var reviews = _reviewService.GetReviews();
            var newsVm = (Mapper.Map<IEnumerable<News>, IEnumerable<NewsViewModel>>(newses));
            var gamesVm = (Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(games));
            var reviewsVm = (Mapper.Map<IEnumerable<Review>, IEnumerable<ReviewViewModel>>(reviews));
            ViewBag.game = gamesVm.OrderByDescending(v => v.AvarageRate).Take(5);
            ViewBag.review = reviewsVm.OrderByDescending(v => v.PublishedDate).Take(5);
            return View(newsVm.OrderByDescending(l => l.PublishedDate));
        }

        public ActionResult OldNews()
        {
            var news = _newsService.GetNews();
            var newsVm = (Mapper.Map<IEnumerable<News>, IEnumerable<NewsViewModel>>(news));
            return View(newsVm.OrderByDescending(l => l.PublishedDate));
        }

        public ActionResult Statistics()
        {
            var StatisticsView = new StatisticsViewModel();


            StatisticsView.ReviewChart = MakeReviewHighchart();
            StatisticsView.GameChart = MakeGameHighchart();
            StatisticsView.RateChart = MakeRateHighchart();
            StatisticsView.CommentChart = MakeCommentHighchart();
            StatisticsView.UserChart = MakeUserHighchart();
            StatisticsView.NewsChart = MakeNewsHighchart();
            StatisticsView.ActiveUsersChart = MakeActiveUsersHighchart();
            StatisticsView.ActiveModeratorsChart = MakeActiveModeratorsHighchart();
            StatisticsView.ReviewMonthChart = MakeReviewMonthHighchart();
            StatisticsView.GameMonthChart = MakeGameMonthHighchart();
            StatisticsView.RateMonthChart = MakeRateMonthHighchart();
            StatisticsView.CommentMonthChart = MakeCommentMonthHighchart();
            StatisticsView.UserMonthChart = MakeUserMonthHighchart();
            StatisticsView.NewsMonthChart = MakeNewsMonthHighchart();

            return View("Statistics", StatisticsView);
        }




        public Highcharts MakeReviewHighchart()
        {
            var data = (
             from month in Enumerable.Range(0, 12)
             let key = new { Year = DateTime.Now.AddMonths(-month).Year, Month = DateTime.Now.AddMonths(-month).Month }
             join revision in _context.Reviews on key
           equals new
           {

               revision.PublishedDate.Year,
               revision.PublishedDate.Month
           } into g
             select new ChartModel() { Date = key.Month.ToString("D2") + "." + key.Year.ToString(), Count = g.Count() }).OrderBy(g => g.Date.Substring(3, 4)).ThenBy(g => g.Date.Substring(0, 2));

            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart1")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość dodanych recenzji w ciągu ostatniego roku" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba recenzji" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })

                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość recenzji"},
                        });

            return chart;
        }

        public Highcharts MakeGameHighchart()
        {
            var data = (
             from month in Enumerable.Range(0, 12)
             let key = new { Year = DateTime.Now.AddMonths(-month).Year, Month = DateTime.Now.AddMonths(-month).Month }
             join revision in _context.Games on key
           equals new
           {

               revision.PublishedDate.Year,
               revision.PublishedDate.Month
           } into g
             select new ChartModel() { Date = key.Month.ToString("D2") + "." + key.Year.ToString(), Count = g.Count() }).OrderBy(g => g.Date.Substring(3, 4)).ThenBy(g => g.Date.Substring(0, 2));

            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart2")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość dodanych gier w ciągu ostatniego roku" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba gier" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = false },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość gier"},
                        });

            return chart;
        }

        public Highcharts MakeCommentHighchart()
        {
            var data = (
             from month in Enumerable.Range(0, 12)
             let key = new { Year = DateTime.Now.AddMonths(-month).Year, Month = DateTime.Now.AddMonths(-month).Month }
             join revision in _context.Comments on key
           equals new
           {

               revision.PublishedDate.Year,
               revision.PublishedDate.Month
           } into g
             select new ChartModel() { Date = key.Month.ToString("D2") + "." + key.Year.ToString(), Count = g.Count() }).OrderBy(g => g.Date.Substring(3, 4)).ThenBy(g => g.Date.Substring(0, 2));

            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart3")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość dodanych komentarzy w ciągu ostatniego roku" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba komentarzy" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = false },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość komentarzy"},
                        });

            return chart;
        }

        public Highcharts MakeUserHighchart()
        {
            var data = (
             from month in Enumerable.Range(0, 12)
             let key = new { Year = DateTime.Now.AddMonths(-month).Year, Month = DateTime.Now.AddMonths(-month).Month }
             join revision in _context.Users on key
           equals new
           {
               revision.RegisterDate.Year,
               revision.RegisterDate.Month
           } into g
             select new ChartModel() { Date = key.Month.ToString("D2") + "." + key.Year.ToString(), Count = g.Count() }).OrderBy(g => g.Date.Substring(3, 4)).ThenBy(g => g.Date.Substring(0, 2));


            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart4")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość zarejestrowanych użytkowników w ciągu ostatniego roku" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba uzytkonwików" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = false },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość użytkowników"},
                        });

            return chart;
        }

        public Highcharts MakeRateHighchart()
        {
            var data = (
             from month in Enumerable.Range(0, 12)
             let key = new { Year = DateTime.Now.AddMonths(-month).Year, Month = DateTime.Now.AddMonths(-month).Month }
             join revision in _context.Rates on key
           equals new
           {

               revision.PublishedDate.Year,
               revision.PublishedDate.Month
           } into g
             select new ChartModel() { Date = key.Month.ToString("D2") + "." + key.Year.ToString(), Count = g.Count() }).OrderBy(g => g.Date.Substring(3, 4)).ThenBy(g => g.Date.Substring(0, 2));


            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart5")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość dodanych ocen w ciągu ostatniego roku" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba ocen" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = false },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość ocen"},
                        });

            return chart;
        }

        public Highcharts MakeNewsHighchart()
        {
            var data = (
             from month in Enumerable.Range(0, 12)
             let key = new { Year = DateTime.Now.AddMonths(-month).Year, Month = DateTime.Now.AddMonths(-month).Month }
             join revision in _context.News on key
           equals new
           {

               revision.PublishedDate.Year,
               revision.PublishedDate.Month
           } into g
             select new ChartModel() { Date = key.Month.ToString("D2") + "." + key.Year.ToString(), Count = g.Count() }).OrderBy(g => g.Date.Substring(3, 4)).ThenBy(g => g.Date.Substring(0, 2));


            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart6")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość dodanych newsów w ciągu ostatniego roku" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba newsów" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = false },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość newsów"},
                        });

            return chart;
        }

        private Highcharts MakeNewsMonthHighchart()
        {
            var pastDate = DateTime.Now.Date.AddMonths(-1);
            var data = from p in _context.News.AsEnumerable()
                       where p.PublishedDate.Date > pastDate
                       group p by p.PublishedDate.Date into pgroup
                       let count = pgroup.Count()
                       //orderby count descending
                       select new ChartModel
                       {
                           Date = pgroup.Key.Day.ToString("D2") + "." + pgroup.Key.Month.ToString("D2"),
                           Count = count
                       };

            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart7")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość dodanych newsów w ciągu ostatniego miesiąca" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba newsów" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = false },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość newsów"},
                        });

            return chart;
        }

        private Highcharts MakeUserMonthHighchart()
        {
            var pastDate = DateTime.Now.Date.AddMonths(-1);
            var data = from p in _context.Users.AsEnumerable()
                       where p.RegisterDate.Date > pastDate
                       group p by p.RegisterDate.Date into pgroup
                       let count = pgroup.Count()
                       //orderby count descending
                       select new ChartModel
                       {
                           Date = pgroup.Key.Day.ToString("D2") + "." + pgroup.Key.Month.ToString("D2"),
                           Count = count
                       };

            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart8")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość zarejestrowanych użytkowników w ciągu ostatniego miesiąca" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba użytkowników" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = false },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość użytkowników"},
                        });

            return chart;
        }

        private Highcharts MakeCommentMonthHighchart()
        {
            var pastDate = DateTime.Now.Date.AddMonths(-1);
            var data = from p in _context.Comments.AsEnumerable()
                       where p.PublishedDate.Date > pastDate
                       group p by p.PublishedDate.Date into pgroup
                       let count = pgroup.Count()
                       //orderby count descending
                       select new ChartModel
                       {
                           Date = pgroup.Key.Day.ToString("D2") + "." + pgroup.Key.Month.ToString("D2"),
                           Count = count
                       };

            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart88")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość dodanych komentarzy w ciągu ostatniego miesiąca" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba komentarzy" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = false },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość komentarzy"},
                        });

            return chart;
        }

        private Highcharts MakeRateMonthHighchart()
        {
            var pastDate = DateTime.Now.Date.AddMonths(-1);
            var data = from p in _context.Rates.AsEnumerable()
                       where p.PublishedDate.Date > pastDate
                       group p by p.PublishedDate.Date into pgroup
                       let count = pgroup.Count()
                       //orderby count descending
                       select new ChartModel
                       {
                           Date = pgroup.Key.Day.ToString("D2") + "." + pgroup.Key.Month.ToString("D2"),
                           Count = count
                       };

            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart9")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość dodanych ocen w ciągu ostatniego miesiąca" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba ocen" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = false },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość ocen"},
                        });

            return chart;
        }

        private Highcharts MakeGameMonthHighchart()
        {
            var pastDate = DateTime.Now.Date.AddMonths(-1);
            var data = from p in _context.Games.AsEnumerable()
                       where p.PublishedDate.Date > pastDate
                       group p by p.PublishedDate.Date into pgroup
                       let count = pgroup.Count()
                       //orderby count descending
                       select new ChartModel
                       {
                           Date = pgroup.Key.Day.ToString("D2") + "." + pgroup.Key.Month.ToString("D2"),
                           Count = count
                       };

            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart0")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość dodanych gier w ciągu ostatniego miesiąca" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba gier" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = true },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość gier"},
                        });

            return chart;
        }

        private Highcharts MakeReviewMonthHighchart()
        {


            var pastDate = DateTime.Now.Date.AddMonths(-1);
            var data = from p in _context.Reviews.AsEnumerable()
                       where p.PublishedDate.Date > pastDate
                       group p by p.PublishedDate.Date into pgroup
                       let count = pgroup.Count()
                       //orderby count descending
                       select new ChartModel()
                       {
                           Date = (pgroup.Key.Day).ToString("D2") + "." + (pgroup.Key.Month).ToString("D2"),
                           Count = count
                       };

            var xMonth = data.Select(i => i.Date).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart55")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line, Width = 1000 })
                .SetTitle(new Title { Text = "Ilość dodanych recenzji w ciągu ostatniego miesiąca" })
                .SetXAxis(new XAxis { Categories = xMonth })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba recenzji" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = true },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "ilość recenzji"},
                        });

            return chart;
        }

        private Highcharts MakeActiveModeratorsHighchart()
        {
            var list = new List<ChartModelUser>();
            foreach (var moderator in _context.Users.Where(c => c.Moderator == true))
            {
                int newsCount =
                    _context.News.Count(
                        g =>
                            g.PublishedDate.Month == DateTime.Now.Month - 1 && g.PublishedDate.Year == DateTime.Now.Year &&
                            g.UserId == moderator.Id);
                list.Add(new ChartModelUser() { Count = newsCount, UserName = moderator.UserName });

            }


            var data = list.OrderByDescending(c => c.Count).Take(5);

            var xUser = data.Select(i => i.UserName).ToArray();
            var yCount = data.ToList().Select(i => new object[] { i.Count }).ToArray();


            var chart = new Highcharts("chart44")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column, Width = 1000 })
                .SetTitle(new Title { Text = "Najbardziej aktywni moderatorzy z poprzedniego miesiąca" })
                .SetXAxis(new XAxis { Categories = xUser })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "liczba dodanych newsów" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = false },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCount), Name = "Added news"},
                        });

            return chart;
        }

        private Highcharts MakeActiveUsersHighchart()
        {
            var list = new List<ChartModelUser2>();
            foreach (var user in _context.Users)
            {

                var reviewsCount = _context.Reviews.Count(g =>
                           g.PublishedDate.Month == DateTime.Now.Month - 1 && g.PublishedDate.Year == DateTime.Now.Year &&
                           g.UserId == user.Id);
                var ratesCount = _context.Rates.Count(g =>
                           g.PublishedDate.Month == DateTime.Now.Month - 1 && g.PublishedDate.Year == DateTime.Now.Year &&
                           g.UserId == user.Id);
                var commentsCount = _context.Comments.Count(g =>
                           g.PublishedDate.Month == DateTime.Now.Month - 1 && g.PublishedDate.Year == DateTime.Now.Year &&
                           g.UserId == user.Id);
                var count = commentsCount + ratesCount + reviewsCount;
                list.Add(new ChartModelUser2() { UserName = user.UserName, CountComments = commentsCount, CountRates = ratesCount, CountReviews = reviewsCount, Count = count });

            }


            var data = list.OrderByDescending(c => c.Count).Take(5);

            var xUser = data.Select(i => i.UserName).ToArray();
            var yReviewsCount = data.ToList().Select(i => new object[] { i.CountReviews }).ToArray();
            var yRatesCount = data.ToList().Select(i => new object[] { i.CountRates }).ToArray();
            var yCommentsCount = data.ToList().Select(i => new object[] { i.CountComments }).ToArray();

            var chart = new Highcharts("chart33")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column, Width = 1000 })
                .SetTitle(new Title { Text = "Najbardziej aktywni użytkownicy z poprzedniego miesiąca" })
                .SetXAxis(new XAxis { Categories = xUser })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "ilość" } })
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return  this.x +': '+this.y; }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels { Enabled = true },

                    }
                })
                .SetSeries(new[]
                {
                    new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yReviewsCount), Name = "Added reviews"},
                        new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yRatesCount), Name = "Added rates"},
                new Series {
                        Data = new DotNet.Highcharts.Helpers.Data(yCommentsCount), Name = "Added comments"}
                        });

            return chart;
        }
    }
}