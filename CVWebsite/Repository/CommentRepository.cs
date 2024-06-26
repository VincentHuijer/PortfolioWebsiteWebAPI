﻿namespace CVWebsite.Repository
{
    using global::CVWebsite.Data;
    using global::CVWebsite.Interfaces;
    using global::CVWebsite.Models;

    namespace CVWebsite.Repository
    {
        public class CommentRepository : ICommentRepository
        {
            private readonly DataContext _context;

            public CommentRepository(DataContext context)
            {
                _context = context;
            }

            public Comment GetComment(int id)
            {
                return _context.Comments.Where(c => c.Id == id).FirstOrDefault();
            }

            public bool CommentExists(int id)
            {
                return _context.Comments.Any(c => c.Id == id);
            }

            public ICollection<Comment> GetComments()
            {
                return _context.Comments.OrderBy(c => c.Id).ToList();
            }
            public void CreateComment(Comment comment)
            {
                _context.Add(comment);
                _context.SaveChanges();
            }

           
            public bool UpdateComment(Comment comment)
            {
                _context.Update(comment);
                return Save();
            }
            public bool UpdateComment(int id)
            {
                _context.Update(id);
                return Save();
            }

            public bool DeleteComment(Comment comment)
            {
                _context.Remove(comment);
                return Save();
            }


            public bool Save()
            {
                var saved = _context.SaveChanges();
                return saved > 0 ? true : false;
            }

        }
    }
}
