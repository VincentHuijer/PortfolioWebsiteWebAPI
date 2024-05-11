using CVWebsite.Models;

namespace CVWebsite.Interfaces
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetComments();
        Comment GetComment(int id);
        bool CommentExists(int id);
        void CreateComment(Comment comment);
        void DeleteComment(Comment comment);
        void UpdateComment(int id);
        void UpdateComment(Comment comment);
    }
}