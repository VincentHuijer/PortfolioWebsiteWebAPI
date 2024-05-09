using CVWebsite.Models;

namespace CVWebsite.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int id);
        Book GetBook(string name);
        bool BookExists(int bookId);
    }
}