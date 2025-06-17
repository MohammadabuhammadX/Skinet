using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; } //What's the criteria of the thing that we're going to get and if i compare it to what in prodcutrepository ,It could be where the product has a type of on or type Id of one
        List<Expression<Func<T, Object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; } //if we want to enable paging or not

    }
}
