using CVWebsite.Data;
using CVWebsite.Interfaces;
using CVWebsite.Models;

namespace CVWebsite.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book GetBook(string name)
        {
            return _context.Books.FirstOrDefault(b => b.Name == name);
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(b => b.Id == id);
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(b => b.Name).ToList();
        }
    }
}
