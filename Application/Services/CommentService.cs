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
    public interface ICommentService
    {
        IEnumerable<Comment> GetComments();
        Comment GetCommentById(int id);
        Comment GetEmptyCommentForGame(int gameId);
        void CreateComment(Comment comment, string userName);
        void EditComment(Comment comment);
        void RemoveComment(int id);

    }
    public class CommentService : ICommentService
    {
        private CrudContext _context;
        public CommentService(CrudContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments.Include(r => r.Game).Include(r => r.User).ToList();
        }


        public Comment GetCommentById(int id)
        {
            var comment = _context.Comments.Single(r => r.Id == id);
            return comment;
        }

        public Comment GetEmptyCommentForGame(int gameId)
        {

            var game = _context.Games.Single(r => r.Id == gameId);

            var emptyComment = new Comment()
            {
                GameId = gameId,
                Game = game,
                PublishedDate = DateTime.Today
            };

            return emptyComment;
        }


        public void CreateComment(Comment comment, string userName)
        {
            var userId = _context.Users.Single(u => u.UserName == userName).Id;

            comment.UserId = userId;
            comment.PublishedDate = DateTime.Today;

            _context.Comments.Add(comment);
            _context.SaveChanges();

        }


        public void EditComment(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            _context.SaveChanges();
        }



        public void RemoveComment(int id)
        {
            Comment comment = _context.Comments.Find(id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }


}
