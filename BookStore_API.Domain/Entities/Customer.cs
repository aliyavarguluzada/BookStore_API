﻿using BookStore_API.Domain.Entities.Common;

namespace BookStore_API.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
