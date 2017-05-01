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
        
        public DbSet<Game> Games { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Gameplay> Gameplays{ get; set; }
        public DbSet<Problem> Problems { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
