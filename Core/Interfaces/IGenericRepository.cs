using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity 
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        void Add(T entity);    //none of these are asynchronous methods and the reason for this is that we're not going to be directly adding these to the database when we use any of add, delete and Update
        void Update(T entity); // what we saying to ef when we use these is we want to add this so track it. and this is happening in the memory it's not happening in SQL 
        void Delete(T entity); //our repo is not responsible for saving changes to the database that's left to our uow.

    }
}
