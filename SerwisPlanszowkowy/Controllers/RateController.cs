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
using Application.Services;

namespace SerwisPlanszowkowy.Controllers
{
    public class RateController : Controller
    {

        private IRateService _rateService;
        private IGameService _gameService { get; set; }

        public RateController(IRateService rateService, IGameService gameService)
        {
            _rateService = rateService;
            _gameService = gameService;
        }

        // GET: Rates
        public ActionResult Index()
        {
            var viewModelList = (Mapper.Map<IEnumerable<Rate>, IEnumerable<RateViewModel>>(_rateService.GetRates()));
            return View(viewModelList);
        }

        // GET: Rates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rate = _rateService.GetRateById((int)id);
            if (rate == null)
            {
                return HttpNotFound("Rate with id " + id + "doesn't exist");
            }
            return View(rate);

        }

        // GET: Rates/Create
        public ActionResult Create(int gameId)
        {

            var model = _rateService.GetEmptyRateForGame(gameId);

            return View(model);

        }

        // POST: Rates/Create     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value,GameId,UserId")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                _rateService.CreateRate(rate, User.Identity.Name);
                return RedirectToAction("Details", "Game", new { Id = rate.GameId });
            }

            ViewBag.GameId = new SelectList(_gameService.GetAcceptedGames(), "Id", "Name", rate.GameId);
            return View(rate);
        }

        // GET: Rates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var rate = _rateService.GetRateById((int)id);
                ViewBag.GameId = new SelectList(_gameService.GetAcceptedGames(), "Id", "Name", rate.GameId);
                return View(rate);
            }
            catch
            {
                return HttpNotFound("Rate with id " + id + "doesn't exist");
            }

        }

        // POST: Rates/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value,GameId,UserId, PublishedDate")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                _rateService.EditRate(rate);
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
           
                var rate = _rateService.GetRateById((int)id);
            if(rate ==null)
                return HttpNotFound("Rate with id " + id + "doesn't exist");
            return View(rate);
     
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _rateService.RemoveRate(id);
            return RedirectToAction("Index");
        }


    }
}
