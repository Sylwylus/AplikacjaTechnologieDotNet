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

namespace SerwisPlanszowkowy.Controllers
{
    public class HomeController : Controller
    {
        private INewsService _newsService { get; set; }
        private IGameService _gameService { get; set; }
        private IReviewService _reviewService { get; set; }
        public  HomeController(INewsService newsService, IGameService gameService, IReviewService reviewService)
        {
            _newsService = newsService;
            _gameService = gameService;
            _reviewService = reviewService;
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
        
    }
}