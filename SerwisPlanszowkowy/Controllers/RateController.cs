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
using AutoMapper;
using SerwisPlanszowkowy.ViewModels;

namespace SerwisPlanszowkowy.Controllers
{
    public class RateController : Controller
    {
        private CrudContext db = new CrudContext();

        // GET: Rates
        public ActionResult Index()
        {
            var rates = db.Rates.Include(r => r.Game).Include(r => r.User);
            var viewModelList = (Mapper.Map<IEnumerable<Rate>, IEnumerable<RateViewModel>>(rates));
            return View(viewModelList.ToList());
        }

        // GET: Rates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // GET: Rates/Create
        public ActionResult Create(int gameId)
        {

            var game = db.Games.Find(gameId);

            var model = new Rate()
            {
                GameId = gameId,
                Game = game,
            };
          
      
            
            return View(model);
        }

        // POST: Rates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value,GameId,UserId")] Rate rate)
        {
            foreach(var item in db.Users)
            {
                if(item.UserName==User.Identity.Name)
                {
                    rate.UserId = item.Id;
                }
            }
            rate.PublishedDate = DateTime.Today;
            if (ModelState.IsValid)
            {
                db.Rates.Add(rate);
                db.SaveChanges();
                return RedirectToAction("Details", "Game", new {Id= rate.GameId});
            }

            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", rate.GameId);
            return View(rate);
        }

        // GET: Rates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", rate.GameId);
            return View(rate);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value,GameId,UserId, PublishedDate")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Game", new { Id = rate.GameId });
            }
     
            return View(rate);
        }

        // GET: Rates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rate rate = db.Rates.Find(id);
            db.Rates.Remove(rate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
