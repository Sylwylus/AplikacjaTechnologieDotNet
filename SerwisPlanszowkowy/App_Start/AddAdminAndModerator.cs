using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Model;
using Microsoft.AspNet.Identity;
using SerwisPlanszowkowy.Controllers;

namespace SerwisPlanszowkowy.App_Start
{
    public class AddAdminAndModerator
    {
        
        public static void InitialRoleUser()
        {
            
           /* var account = new AccountController(new Data.CrudContext(), new Data.Identity.ApplicationUserManager(new CustomUserStore );
            account.ApplicationUserManager.AddToRole(2, "Administrator");
            account.ApplicationUserManager.AddToRole(2, "Moderator");
            account.ApplicationUserManager.AddToRole(3, "Moderator");*/
       
        }

    }
}