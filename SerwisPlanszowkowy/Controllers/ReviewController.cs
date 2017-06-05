using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Data;
using Domain.Model;
using SerwisPlanszowkowy.ViewModels;

namespace SerwisPlanszowkowy.Controllers
{
    public class ReviewController : Controller
    {
        private CrudContext db = new CrudContext();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Game).Include(r => r.User);
            return View(reviews.ToList());
        }

        // GET: Reviews
        public ActionResult NotAcceptedReviews()
        {
            var reviews = db.Reviews.Include(r => r.Game).Include(r => r.User).Where(c=> c.Accepted==false);
            return View(reviews.ToList());
        }

        
        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create(int gameId)
        {
            var game = db.Games.Include(c=>c.Rates).First(c => c.Id == gameId);
           
            var viewModel = new ReviewViewModel()
            {
               GameId = gameId,
               Game =  game,
               PublishedDate = DateTime.Today
            };


            return View(viewModel);

        }

        // POST: Reviews/Create
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ReviewViewModel model)
       {

           Review review = new Review
           {
               Accepted = false,
               PublishedDate = DateTime.Now,
               Title = model.Title,
               UserId = model.UserId,
               GameId = model.GameId,
               Content = model.Content
           };

           foreach (var item in db.Users)
            {
                if (item.UserName == User.Identity.Name)
                {
                    review.UserId = item.Id;
                }
            }

            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Details", "Game", new { Id = review.GameId });
            }

            

          
            return View(model);
        }



       // GET: Reviews/Create
       public ActionResult CreateFromIndex()
       {
           var games = db.Games.Where(c => c.Accepted == true);
           var gameViewModels = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(games);
           var data = gameViewModels.ToList().Select(t => new GroupedSelectListItem
           {
               GroupKey = t.CategoryName.ToString(),
               GroupName = t.CategoryName,
               Text = t.Name,
               Value = t.Id.ToString()
           });
           var viewModel = new ReviewViewModel()
           {
               Games = data,
               PublishedDate = DateTime.Today
           };


           return View(viewModel);

       }

       // POST: Reviews/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult CreateFromIndex(ReviewViewModel model)
       {

           Review review = new Review
           {
               Accepted = false,
               PublishedDate = DateTime.Now,
               Title = model.Title,
               UserId = model.UserId,
               GameId = model.GameId,
               Content = model.Content
           };

           foreach (var item in db.Users)
           {
               if (item.UserName == User.Identity.Name)
               {
                   review.UserId = item.Id;
               }
           }

           if (ModelState.IsValid)
           {
               db.Reviews.Add(review);
               db.SaveChanges();
               return RedirectToAction("Index", "Review");
           }


           var games = db.Games.Where(c => c.Accepted == true);
           var gameViewModels = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(games);
           var data = gameViewModels.ToList().Select(t => new GroupedSelectListItem
           {
               GroupKey = t.CategoryName.ToString(),
               GroupName = t.CategoryName,
               Text = t.Name,
               Value = t.Id.ToString()
           });

           model.Games = data;

           return View(model);
       }






        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", review.GameId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PublishedDate,Content,GameId,UserId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", review.GameId);
            return View(review);
        }



        // GET: Reviews/Accept/5
        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
           var model= Mapper.Map<Review, NotAcceptedReviewViewModel>(review);
            model.Delete = false;
           
            if (review == null)
            {
                return HttpNotFound();
            }
            return View("NotAcceptedDetails", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Accept(NotAcceptedReviewViewModel model)
        {
            
            if(model.Delete==false)
            { 
                if (ModelState.IsValid)
                {
                Review review = new Review
                {
                    Accepted = true,
                    PublishedDate = model.PublishedDate,
                    Id = model.Id,
                    GameId = model.GameId,
                    UserId = model.UserId,
                    Content = model.Content,
                    Title = model.Title
                };

                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NotAcceptedReviews");
            }
                }
            else
            {
               
                Review review = db.Reviews.Find(model.Id);
                db.Reviews.Remove(review);
                db.SaveChanges();
                return RedirectToAction("NotAcceptedReviews");
            }
       
            return View("NotAcceptedDetails", model);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
