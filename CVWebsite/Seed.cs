using CVWebsite.Data;
using CVWebsite.Models;

namespace CVWebsite
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            dataContext.Database.EnsureCreated();

            if (!dataContext.Books.Any())
            {
                var books = new List<Book>
            {
                new Book { Id = 1, ISBN = "9780140449334", Name = "Book 1", Author = "Marucs Aurelius", Review = "Great book!" },
                new Book { Id = 2, ISBN = "9780141018812", Name = "On The Shortness Of Life", Author = "Lucius Seneca", Review = "Interesting read." },
            };

                dataContext.Books.AddRange(books); //adds collection of book sto database context
                dataContext.SaveChanges();
            }

            if (!dataContext.Comments.Any())
            {
                var comments = new List<Comment>
            {
                new Comment { Id = 1, Email = "Test@gmail.com", FirstName = "John", LastName = "Doe", PostDate = DateTime.Now.AddDays(-5) },
                new Comment { Id = 2, Email = "Test2@gmail.com", FirstName = "Jane", LastName = "Smith", PostDate = DateTime.Now.AddDays(-3) },
            };

                dataContext.Comments.AddRange(comments);
                dataContext.SaveChanges();
            }
        }
    }
}


