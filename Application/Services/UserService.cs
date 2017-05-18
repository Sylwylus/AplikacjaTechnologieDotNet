using Data;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Application.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);       
        void CreateUser(User user);
        void EditUser(User user);
        void RemoveUser(int id);

    }
    public class UserService : IUserService
    {
        private CrudContext _context;
        public UserService(CrudContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }


        public User GetUserById(int id)
        {
            var user = _context.Users.Single(r => r.Id == id);
            return user;
        }

       

        public void CreateUser(User user)
        {
           
            _context.Users.Add(user);
            _context.SaveChanges();

        }


        public void EditUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }



        public void RemoveUser(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }


}
