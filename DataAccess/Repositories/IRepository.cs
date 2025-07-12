// DataAccess/Repositories/IRepository.cs
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        LucySalesDbContext Context { get; } // Thêm property này

        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T? GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(object id);
        int SaveChanges();
    }
}