using BookStore_API.Domain.Entities.Common;

namespace BookStore_API.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public long Price { get; set; }
    }
}
