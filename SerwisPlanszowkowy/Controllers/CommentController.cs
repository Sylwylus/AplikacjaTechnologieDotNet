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
    public class CommentController : Controller
    {
        private ICommentService _commentService { get; set; }
        private IGameService _gameService { get; set; }
        public CommentController(ICommentService commentService, IGameService gameService)
        {
            _commentService = commentService;
            _gameService = gameService;
        }

        // GET: Comments
        public ActionResult Index()
        {
            var comments = _commentService.GetComments();
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.GetCommentById((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create(int gameId)
        {
            var comment = _commentService.GetEmptyCommentForGame(gameId);

            return View(comment);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PublishedDate,Content,GameId,UserId")] Comment comment)
        {  
           
            if (ModelState.IsValid)
            {
                _commentService.CreateComment(comment, User.Identity.Name);
                return RedirectToAction("Details", "Game", new { Id = comment.GameId });
            }

            ViewBag.GameId = new SelectList(_gameService.GetAcceptedGames(), "Id", "Name", comment.GameId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.GetCommentById((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
         
            return View(comment);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PublishedDate,Content,GameId,UserId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentService.EditComment(comment);
                return RedirectToAction("Details", "Game", new { Id = comment.GameId });
            }
          
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.GetCommentById((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _commentService.RemoveComment(id);
            return RedirectToAction("Index");
        }

       
    }
}
