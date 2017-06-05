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
using Application.Services;

namespace SerwisPlanszowkowy.Controllers
{
    public class GameController : Controller
    {
        private IGameService _gameService { get; set; }
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET: /Game/
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder, int? filterCategory, int? currentFilterCategory)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RateSortParm = sortOrder == "Rate" ? "rate_desc" : "Rate";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
            ViewBag.PublisherSortParm = sortOrder == "Publisher" ? "publisher_desc" : "Publisher";
            ViewBag.Categorys = new SelectList(_gameService.GetCategoriesDictionary(), "Id", "Name", "filterCategory");
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
            var games = _gameService.GetFilteredGames(searchString, filterCategory);

            var viewModelList = (Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(games));
            
            var gamesVm = from s in viewModelList
                  select s;
            switch (sortOrder)
            {
                case "name_desc":
                    gamesVm = gamesVm.OrderByDescending(s => s.Name);
                    break;
                case "Rate":
                    gamesVm = gamesVm.OrderBy(s => s.AvarageRate);
                    break;
                case "rate_desc":
                    gamesVm = gamesVm.OrderByDescending(s => s.AvarageRate);
                    break;
                case "Category":
                    gamesVm = gamesVm.OrderBy(s => s.CategoryName);
                    break;
                case "category_desc":
                    gamesVm = gamesVm.OrderByDescending(s => s.CategoryName);
                    break;
                case "Publisher":
                    gamesVm = gamesVm.OrderBy(s => s.Publisher);
                    break;
                case "publisher_desc":
                    gamesVm = gamesVm.OrderByDescending(s => s.Publisher);
                    break;
                default:
                    gamesVm = gamesVm.OrderBy(s => s.Name);
                    break;
            }
         
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(gamesVm.ToPagedList(pageNumber, pageSize));
        
        }

        // GET: /Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var game = _gameService.GetGameById((int)id);            
            if (game == null)
            {
                return HttpNotFound();
            }
            var gameViewModel = Mapper.Map<Game, GameDetailsViewModel>(game);
            return View(gameViewModel);
        }

        // GET: /Game/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_gameService.GetCategoriesDictionary(), "Id", "Name");
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
                _gameService.CreateGame(game);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_gameService.GetCategoriesDictionary(), "Id", "Name", game.CategoryId);
            return View(model);
        }

        // GET: /Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _gameService.GetGameById((int)id);
            var model = Mapper.Map<Game, GameCreateEditViewModel>(game);
            model.OldPhoto = game.Photo;
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_gameService.GetCategoriesDictionary(), "Id", "Name", game.CategoryId);
            return View(model);
        }

        // POST: /Game/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameCreateEditViewModel model, HttpPostedFileBase image)
        {
            var game = new Game
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
            if (image == null)
            {
                game.Photo = model.OldPhoto;
            }
            else
            {   
                game.Photo = new byte[image.ContentLength];
                image.InputStream.Read(game.Photo, 0, image.ContentLength);
            }
            
            if (ModelState.IsValid)
            {
                _gameService.EditGame(game);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_gameService.GetCategoriesDictionary(), "Id", "Name", game.CategoryId);
            return View(model);
        }

        // GET: /Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _gameService.GetGameById((int)id);
          
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
            _gameService.RemoveGame(id);
            return RedirectToAction("Index");
        }

     
        // GET: /Game/
        public ActionResult NotAcceptedGames()
        {

            var games = _gameService.GetNotAcceptedGames();

            var viewModelList = (Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(games));
            return View(viewModelList.ToList());
        }

        // GET: /Game/Accept/5
        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _gameService.GetGameById((int)id);
            var gameViewModel = Mapper.Map<Game, NotAcceptedGameDetailsViewModel>(game);
            gameViewModel.Delete = false;
            if (game == null)
            {
                return HttpNotFound();
            }
            return View("NotAcceptedDetails", gameViewModel);
        }



        // POST: /Game/Accept/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Accept(NotAcceptedGameDetailsViewModel model)
        {

            if (model.Delete == false)
            {
                if (ModelState.IsValid)
                {
                    _gameService.AcceptGame(model.Id);
                    return RedirectToAction("NotAcceptedGames");
                }
            }
            else
            {

                _gameService.RemoveGame(model.Id);
                return RedirectToAction("NotAcceptedGames");
            }


            return View("NotAcceptedDetails", model);
        }

        public ActionResult Top20Games()
        {
            var games = _gameService.GetAcceptedGames();
            var viewModelList = (Mapper.Map<IEnumerable<Game>, IEnumerable<GameDetailsViewModel>>(games));
            return View(viewModelList.ToList().OrderByDescending(t => t.AvarageRate));
        }
    }
}
