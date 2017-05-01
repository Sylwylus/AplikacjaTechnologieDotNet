using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data
{
    public class CustomUserStore : UserStore<User, CustomRole, int,
       CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(CrudContext context): base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(CrudContext context): base(context)
        {
        }
    } 
}
