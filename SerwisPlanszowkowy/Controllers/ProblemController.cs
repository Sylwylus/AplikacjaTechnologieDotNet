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
using SerwisPlanszowkowy.ViewModels;
using AutoMapper;

namespace SerwisPlanszowkowy.Controllers
{
    public class ProblemController : Controller
    {
        private CrudContext db = new CrudContext();

        // GET: Problems
        public ActionResult Index()
        {
            var problems = db.Problems.Include(p => p.User);
            var viewModelList = (Mapper.Map<IEnumerable<Problem>, IEnumerable<ProblemViewModel>>(problems));
            return View(viewModelList.ToList());
        }

        // GET: Problems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            var problemViewModel = Mapper.Map<Problem, ProblemViewModel>(problem);
            return View(problemViewModel);
        }

        // GET: Problems/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PublishedDate,Title,Content,UserId")] Problem problem)
        {
            foreach (var item in db.Users)
            {
                if (item.UserName == User.Identity.Name)
                {
                    problem.UserId = item.Id;
                }
            }
            problem.PublishedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Problems.Add(problem);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            var problemViewModel = Mapper.Map<Problem, ProblemViewModel>(problem);
            return View(problemViewModel);
        }


        // GET: Problems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }

            var problemViewModel = Mapper.Map<Problem, ProblemViewModel>(problem);
            return View(problemViewModel);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Problem problem = db.Problems.Find(id);
            db.Problems.Remove(problem);
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
