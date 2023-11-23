﻿using BookStore_API.Application.Repostories;
using BookStore_API.Domain.Entities.Common;
using System.Linq.Expressions;

namespace BookStore_API.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(string id);
    }
}
