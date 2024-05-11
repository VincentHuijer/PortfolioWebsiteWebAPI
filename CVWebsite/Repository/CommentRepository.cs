namespace CVWebsite.Repository
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
                return _context.Comments.FirstOrDefault(c => c.Id == id);
            }

            public bool CommentExists(int id)
            {
                return _context.Comments.Any(b => b.Id == id);
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

            public void DeleteComment (Comment comment)
            {
                _context.Remove(comment);
                _context.SaveChanges();
            }

            public void UpdateComment(Comment comment)
            {
                _context.Update(comment);
                _context.SaveChanges();
            }
            public void UpdateComment(int id)
            {
                _context.Update(id);
                _context.SaveChanges();
            }
            

        }
    }
}
