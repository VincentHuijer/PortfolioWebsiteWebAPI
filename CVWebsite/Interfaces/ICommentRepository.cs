using CVWebsite.Models;

namespace CVWebsite.Interfaces
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetComments();
        Comment GetComment(int id);
        bool CommentExists(int id);
        void CreateComment(Comment comment);
        bool DeleteComment(Comment comment);
        bool UpdateComment(int id);
        bool UpdateComment(Comment comment);
    }
}