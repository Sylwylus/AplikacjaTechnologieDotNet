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
    public interface IGameService
    {
        Game GetGameById(int id);
        IEnumerable<Game> GetAcceptedGames();
        IEnumerable<Game> GetNotAcceptedGames();
        IEnumerable<Game> GetFilteredGames(string searchString, int? categoryFilter);
        void CreateGame(Game game);
        void EditGame(Game game);
        void AcceptGame(int id);
        void RemoveGame(int id);
        IEnumerable<Category> GetCategoriesDictionary();

    }
    public class GameService : IGameService
    {
        private CrudContext _context;
        public GameService(CrudContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetAcceptedGames()
        {
            return _context.Games.Include(g => g.Category).Where(c => c.Accepted == true);
        }

        public IEnumerable<Game> GetNotAcceptedGames()
        {
            return _context.Games.Include(g => g.Category).Where(c => c.Accepted == false);
        }

        public IEnumerable<Category> GetCategoriesDictionary()
        {
            return _context.Categorys.ToList();
        }

        public IEnumerable<Game> GetFilteredGames(string searchString, int? categoryFilter)
        {
            var games = _context.Games.Include(g => g.Category).Where(c => c.Accepted == true);

            if (!string.IsNullOrEmpty(searchString))
            {
                games = games.Where(s => s.Name.Contains(searchString) || s.Publisher.Contains(searchString));
            }
            if (categoryFilter != null)
            {
                games = games.Where(s => s.CategoryId == categoryFilter);
            }

            return games;

        }

        public Game GetGameById(int id)
        {
            var Game = _context.Games.Single(r => r.Id == id);
            return Game;
        }

    

        public void CreateGame(Game game)
        {

            _context.Games.Add(game);
            _context.SaveChanges();

        }


        public void EditGame(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AcceptGame(int id)
        {
            var game = _context.Games.Single(r => r.Id == id);
            game.Accepted = true;
            _context.Entry(game).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveGame(int id)
        {
            Game Game = _context.Games.Find(id);
            _context.Games.Remove(Game);
            _context.SaveChanges();
        }
    }


}
