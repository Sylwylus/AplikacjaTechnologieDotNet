using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Model
{
    public class User : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim> 
    {
        public override int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public bool Moderator { get; set; }
        public bool Administrator { get; set; }
        public override string Email { get; set; }
        public override string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Gameplay> Gameplays { get; set; }
        public virtual ICollection<News> News { get; set; }
   

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
          
            return userIdentity;
        }

     
    }
}
