using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data

{
    public class CrudContext : IdentityDbContext<User, CustomRole,int, CustomUserLogin, CustomUserRole, CustomUserClaim> 
    {
        public CrudContext()
            : base("name=SerwisPlanszowkowyDatabase")
        {
        }
        
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Gameplay> Gameplays{ get; set; }
        public virtual DbSet<Problem> Problems { get; set; }
        public override IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }      
    }
}
