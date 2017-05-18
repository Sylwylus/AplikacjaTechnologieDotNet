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
    public interface IRateService
    {
        IEnumerable<Rate> GetRates();
        Rate GetRateById(int id);
        Rate GetEmptyRateForGame(int gameId);
        void CreateRate(Rate rate, string userName);
        void EditRate(Rate rate);
        void RemoveRate(int id);

    }
    public class RateService : IRateService
    {
        private CrudContext _context;
        public RateService (CrudContext context)
        {
            _context = context;
        }
            
        public IEnumerable<Rate> GetRates()
        {
            return _context.Rates.Include(r => r.Game).Include(r => r.User).ToList();                      
        }

      
        public Rate GetRateById(int id)
        {
            var rate = _context.Rates.Single(r => r.Id == id);            
            return rate;
        }

        public Rate GetEmptyRateForGame(int gameId)
        {

            var game = _context.Games.Single(r => r.Id == gameId);

            var emptyRate = new Rate()
            {
                GameId = gameId,
                Game = game,
            };

            return emptyRate;
        }

      
        public void CreateRate(Rate rate, string userName)
        {
            var userId = _context.Users.Single(u => u.UserName == userName).Id;
          
            rate.UserId = userId;              
            rate.PublishedDate = DateTime.Today;

            _context.Rates.Add(rate);
            _context.SaveChanges();
              
       }
        
    
        public void EditRate(Rate rate)
        {
            _context.Entry(rate).State = EntityState.Modified;
            _context.SaveChanges(); 
        }

       

        public void RemoveRate(int id)
        {
            Rate rate = _context.Rates.Find(id);
            _context.Rates.Remove(rate);
            _context.SaveChanges();
        }
    }

   
}
