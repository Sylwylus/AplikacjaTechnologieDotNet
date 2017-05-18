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
    public interface INewsService
    {
        IEnumerable<News> GetNews();
        News GetNewsById(int id);      
        void CreateNews(News news, string userName);
        void EditNews(News news);
        void RemoveNews(int id);

    }
    public class NewsService : INewsService
    {
        private CrudContext _context;
        public NewsService(CrudContext context)
        {
            _context = context;
        }

        public IEnumerable<News> GetNews()
        {
            return _context.News.Include(r => r.User).ToList();
        }


        public News GetNewsById(int id)
        {
            var news = _context.News.Single(r => r.Id == id);
            return news;
        }
           

        public void CreateNews(News news, string userName)
        {
            var userId = _context.Users.Single(u => u.UserName == userName).Id;

            news.UserId = userId;
            news.PublishedDate = DateTime.Today;

            _context.News.Add(news);
            _context.SaveChanges();

        }


        public void EditNews(News news)
        {
            _context.Entry(news).State = EntityState.Modified;
            _context.SaveChanges();
        }



        public void RemoveNews(int id)
        {
            News news = _context.News.Find(id);
            _context.News.Remove(news);
            _context.SaveChanges();
        }
    }


}
