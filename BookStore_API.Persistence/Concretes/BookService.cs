using BookStore_API.Application.Abstraction;
using BookStore_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_API.Persistence.Concretes
{
    public class BookService : IBookService
    {
        public List<Book> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
