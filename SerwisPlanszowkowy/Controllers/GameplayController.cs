using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain.Model;
using Data;
using SerwisPlanszowkowy.ViewModels;

namespace SerwisPlanszowkowy.Controllers
{
    public class GameplayController : Controller
    {
        private CrudContext db = new CrudContext();

        // GET: /Gameplay/
        public ActionResult Index(int UserId)
        {
           
            var gameplays = db.Gameplays.Include(g => g.Game).Where(g => g.UserId == UserId).OrderByDescending(g=> g.PublishedDate);


            var viewModelList = (Mapper.Map<IEnumerable<Gameplay>, IEnumerable<GameplayViewModel>>(gameplays));
            return View(viewModelList.ToList());
        }

     

        // GET: /Gameplay/Create
        public ActionResult Create()
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
            var viewModel = new GameplayCreateEditViewModel()
            {
                Games = data,
                PublishedDate = DateTime.Today
            };
            
        
            return View(viewModel);
        }

        // POST: /Gameplay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameplayCreateEditViewModel model)
        {

            var gameplay = new Gameplay {GameId = model.GameId, PublishedDate = model.PublishedDate};
            foreach (var item in db.Users)
            {
                if (item.UserName == User.Identity.Name)
                {
                   gameplay.UserId = item.Id;
                }
            }
 
            
            if (ModelState.IsValid)
            {
                db.Gameplays.Add(gameplay);
                db.SaveChanges();
                return RedirectToAction("UserGameplays", "Account");
            }

            var games = db.Games.Where(c=> c.Accepted==true);
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

        // GET: /Gameplay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Gameplay gameplay = db.Gameplays.Find(id);
            var viewModel = Mapper.Map<Gameplay, GameplayCreateEditViewModel>(gameplay);
            var games = db.Games.Where(c => c.Accepted == true);
            var gameViewModels = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(games);
            var data = gameViewModels.ToList().Select(t => new GroupedSelectListItem
            {
                GroupKey = t.CategoryName.ToString(),
                GroupName = t.CategoryName,
                Text = t.Name,
                Value = t.Id.ToString()
            });

            viewModel.Games = data;
            
            if (gameplay == null)
            {
                return HttpNotFound();
            }
         
            return View(viewModel);
        }

        // POST: /Gameplay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PublishedDate,GameId,UserId")] GameplayCreateEditViewModel model)
        {

            var gameplay = new Gameplay { Id = model.Id, GameId = model.GameId, PublishedDate = model.PublishedDate };
            foreach (var item in db.Users)
            {
                if (item.UserName == User.Identity.Name)
                {
                    gameplay.UserId = item.Id;
                }
            }
            
            if (ModelState.IsValid)
            {
                db.Entry(gameplay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserGameplays", "Account");
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

        // GET: /Gameplay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gameplay gameplay = db.Gameplays.Find(id);
            var viewModel = (Mapper.Map<Gameplay, GameplayViewModel>(gameplay));
            
            if (gameplay == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: /Gameplay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gameplay gameplay = db.Gameplays.Find(id);
            db.Gameplays.Remove(gameplay);
            db.SaveChanges();
            return RedirectToAction("UserGameplays", "Account");
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
