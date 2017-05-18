using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Model;
using Application.Services;

namespace SerwisPlanszowkowy.Controllers
{
    public class NewsController : Controller
    {
        private INewsService _newsService { get; set; }
        private IUserService _userService { get; set; }
        public NewsController(IUserService userService, INewsService newsService)
        {
            _userService = userService;
            _newsService = newsService;
        }

        // GET: News
        public ActionResult Index()
        {
            var news = _newsService.GetNews();
            return View(news.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _newsService.GetNewsById((int)id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(_userService.GetUsers(), "Id", "FirstName");
            return View();
        }

        // POST: News/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PublishedDate,Title,Content,UserId")] News news)
        {
           

            if (ModelState.IsValid)
            {
                _newsService.CreateNews(news, User.Identity.Name);
                return RedirectToAction("Index", "Home");
            }

            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _newsService.GetNewsById((int)id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(_userService.GetUsers(), "Id", "FirstName", news.UserId);
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PublishedDate,Title,Content,UserId")] News news)
        {
            if (ModelState.IsValid)
            {
                _newsService.EditNews(news);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.UserId = new SelectList(_userService.GetUsers(), "Id", "FirstName", news.UserId);
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _newsService.GetNewsById((int)id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _newsService.RemoveNews(id);
            return RedirectToAction("Index", "Home");
        }

      
    }
}
