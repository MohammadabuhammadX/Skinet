using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);// p => p.ProductTypeId == Id this what will be replaced by the criteria
            }
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
/*
 * includes is an aggregates , the first part of the query expresstion we're going to pass in query,
 * the second part of this expresstion actually takes two parameters so what we'll fo is we'll open some parentheses,
 * and we'll say current which represents the entity that we're passing in and then the include expression,
 * which is going to be the expression of our includes statement, and what we'll fo is say current.Include(include)
 */