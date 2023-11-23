using BookStore_API.Domain.Entities.Common;

namespace BookStore_API.Domain.Entities
{
    public class Book : Product
    {
        public string Genre { get; set; }
        public string Author { get; set; }
        public DateTime YearPublished { get; set; }
    }
}
