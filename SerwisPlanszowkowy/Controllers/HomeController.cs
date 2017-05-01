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

namespace SerwisPlanszowkowy.Controllers
{
    public class HomeController : Controller
    {
        private CrudContext db = new CrudContext();
        public ActionResult Index()
        {
            var newses = db.News.Include(n => n.User);
            var games = db.Games;
            var reviews = db.Reviews.Include(r => r.User).Include(r => r.Game);
            var viewModelList = (Mapper.Map<IEnumerable<News>, IEnumerable<NewsViewModel>>(newses));
            var viewModelList2 = (Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(games));
           // var viewModelList3 = (Mapper.Map<IEnumerable<Review>, IEnumerable<ReviewViewModel>>(reviews));
            ViewBag.game = viewModelList2.ToList().Where(v => v.Accepted == true).OrderByDescending(v => v.AvarageRate).Take(5);
           // ViewBag.review = viewModelList3.ToList().Where(v => v.Accepted == true).OrderByDescending(v => v.PublishedDate).Take(5);
            return View(viewModelList.ToList().OrderByDescending(l => l.PublishedDate));
        }

        public ActionResult OldNews()
        {
            var newses = db.News.Include(n => n.User);
            var viewModelList = (Mapper.Map<IEnumerable<News>, IEnumerable<NewsViewModel>>(newses));
            return View(viewModelList.ToList().OrderByDescending(l => l.PublishedDate));
        }
        
    }
}