using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; }
            = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T,Object>> includeExpresstion)
        {
            Includes.Add(includeExpresstion);
        }
    }
}
//next is creating a specifiction evaluator class that's going to take look at what's been provided in the specification and then evaluate it and then create a iqueryable that we can pass to a to list function and execute this specification
/*
 * specification evaluator something that's going to take a specification and List of queries and expresstions and evaluate them and generate IQueryable that we're then going to  return so that we can create a list from list of the expresstions that we've built up
 * in our specification evaluator
 */