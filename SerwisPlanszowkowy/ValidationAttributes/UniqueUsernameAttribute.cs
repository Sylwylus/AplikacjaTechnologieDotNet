using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Data;

namespace SerwisPlanszowkowy.ValidationAttributes
{
    public class UniqueUsernameAttribute : ValidationAttribute
    {
        private CrudContext db = new CrudContext();
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var name = value as string;
                if (db.Users.Any(s => s.UserName == (string) value))
                {
                    return false;
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}