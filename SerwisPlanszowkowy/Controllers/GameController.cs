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
using PagedList;

namespace SerwisPlanszowkowy.Controllers
{
    public class GameController : Controller
    {
        private CrudContext db = new CrudContext();

        // GET: /Game/
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder, int? filterCategory, int? currentFilterCategory)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RateSortParm = sortOrder == "Rate" ? "rate_desc" : "Rate";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
            ViewBag.PublisherSortParm = sortOrder == "Publisher" ? "publisher_desc" : "Publisher";
            ViewBag.Categorys = new SelectList(db.Categorys, "Id", "Name", "filterCategory");
            if (!String.IsNullOrEmpty(searchString) || filterCategory != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
                filterCategory = currentFilterCategory;
            }

            ViewBag.CurrentFilter = searchString;
            if (filterCategory == null)
            {
                ViewBag.CurrentFilterCategory = "All";
            }
            else
            {
                ViewBag.CurrentFilterCategory = filterCategory;
            }
            var gamess = db.Games.Include(g => g.Category).Where(c => c.Accepted == true);

           if (!String.IsNullOrEmpty(searchString))
           {
               gamess = gamess.Where(s => s.Name.Contains(searchString)|| s.Publisher.Contains(searchString));
           }
           if (filterCategory!=null)
           {
               gamess = gamess.Where(s => s.CategoryId == filterCategory);
           } 
            var viewModelList = (Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(gamess));
            
            var games = from s in viewModelList
                  select s;
            switch (sortOrder)
            {
                case "name_desc":
                    games = games.OrderByDescending(s => s.Name);
                    break;
                case "Rate":
                    games = games.OrderBy(s => s.AvarageRate);
                    break;
                case "rate_desc":
                    games = games.OrderByDescending(s => s.AvarageRate);
                    break;
                case "Category":
                    games = games.OrderBy(s => s.CategoryName);
                    break;
                case "category_desc":
                    games = games.OrderByDescending(s => s.CategoryName);
                    break;
                case "Publisher":
                    games = games.OrderBy(s => s.Publisher);
                    break;
                case "publisher_desc":
                    games = games.OrderByDescending(s => s.Publisher);
                    break;
                default:
                    games = games.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(games.ToPagedList(pageNumber, pageSize));
        
        }

        // GET: /Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            var gameViewModel = Mapper.Map<Game,GameDetailsViewModel>(game);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(gameViewModel);
        }

        // GET: /Game/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categorys, "Id", "Name");
            return View();
        }

        // POST: /Game/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreateEditViewModel model, HttpPostedFileBase image)
        {
           
          
            var game = new Game
            {
                Accepted = false,
                PublishedDate = model.PublishedDate,
                CategoryId = int.Parse(model.CategoryId),
                MaxNumberOfPlayers = model.MaxNumberOfPlayers,
                MinNumberOfPlayers = model.MinNumberOfPlayers,
                PlayingTime = model.PlayingTime,
                Description = model.Description,
                SuggestedAge = model.SuggestedAge,
                Name = model.Name,
                Publisher = model.Publisher
            };
            if (image != null)
            {
                game.Photo = new byte[image.ContentLength];
                image.InputStream.Read(game.Photo, 0, image.ContentLength);
            }
       
            if (ModelState.IsValid )
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categorys, "Id", "Name", game.CategoryId);
            return View(model);
        }

        // GET: /Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            var model = Mapper.Map<Game, GameCreateEditViewModel>(game);
            model.OldPhoto = game.Photo;
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "Id", "Name", game.CategoryId);
            return View(model);
        }

        // POST: /Game/Edit/5

        [HttpPost]
  [ValidateAntiForgeryToken]
        public ActionResult Edit(GameCreateEditViewModel model, HttpPostedFileBase image)
        {
            Game game;
            if (image == null)
            {
               game = new Game
                {
                    Id = model.Id,
                    Accepted = false,
                    PublishedDate = model.PublishedDate,
                    CategoryId = int.Parse(model.CategoryId),
                    MaxNumberOfPlayers = model.MaxNumberOfPlayers,
                    MinNumberOfPlayers = model.MinNumberOfPlayers,
                    PlayingTime = model.PlayingTime,
                    Description = model.Description,
                    SuggestedAge = model.SuggestedAge,
                    Name = model.Name,
                    Publisher = model.Publisher,
                    Photo = model.OldPhoto

                };
            }
            else
            {
                 game = new Game
                {
                    Id = model.Id,
                    Accepted = false,
                    PublishedDate = model.PublishedDate,
                    CategoryId = int.Parse(model.CategoryId),
                    MaxNumberOfPlayers = model.MaxNumberOfPlayers,
                    MinNumberOfPlayers = model.MinNumberOfPlayers,
                    PlayingTime = model.PlayingTime,
                    Description = model.Description,
                    SuggestedAge = model.SuggestedAge,
                    Name = model.Name,
                    Publisher = model.Publisher

                };
                
                
                game.Photo = new byte[image.ContentLength];
                image.InputStream.Read(game.Photo, 0, image.ContentLength);
            }
            
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categorys, "Id", "Name", game.CategoryId);
            return View(model);
        }

        // GET: /Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
          
            if (game == null)
            {
                return HttpNotFound();
            }
            var model = Mapper.Map<Game, GameDetailsViewModel>(game);
            return View(model);
        }

        // POST: /Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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

        // GET: /Game/
        public ActionResult NotAcceptedGames()
        {
           
            var games = db.Games.Include(g => g.Category).Where(c => c.Accepted == false);
           
            var viewModelList = (Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(games));
            return View(viewModelList.ToList());
        }

    

        public ActionResult Top20Games()
        {
            var games = db.Games.Include(g => g.Category).Where(c => c.Accepted == true);
            var viewModelList = (Mapper.Map<IEnumerable<Game>, IEnumerable<GameDetailsViewModel>>(games));
            return View(viewModelList.ToList().OrderByDescending(t => t.AvarageRate));
        }
    }
}
