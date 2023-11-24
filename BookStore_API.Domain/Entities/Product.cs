using BookStore_API.Domain.Entities.Common;

namespace BookStore_API.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public int Stock { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
