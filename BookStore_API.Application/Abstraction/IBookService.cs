using BookStore_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_API.Application.Abstraction
{
    public interface IBookService
    {
        List<Book> GetBooks();
    }
}
