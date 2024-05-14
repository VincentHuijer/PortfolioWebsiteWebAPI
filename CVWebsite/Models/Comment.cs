namespace CVWebsite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime PostDate { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

    }
}
