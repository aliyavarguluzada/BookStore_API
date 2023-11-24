using BookStore_API.Application.Repositories;
using BookStore_API.Domain.Entities;
using BookStore_API.Persistence.Contexts.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_API.Persistence.Repostories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}
