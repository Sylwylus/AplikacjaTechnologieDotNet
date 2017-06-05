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
    public class UsersController : Controller
    {
        private CrudContext db = new CrudContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users;
            var viewModelList = (Mapper.Map<IEnumerable<User>, IEnumerable<UserDetailsViewModel>>(users));
            return View(viewModelList);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            var userViewModel = Mapper.Map<User, UserDetailsViewModel>(user);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
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
