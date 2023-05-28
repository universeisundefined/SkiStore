using System.Linq;
using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Entities;
using SkiStore.Core.Specifications;

namespace SkiStore.Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)
        {
            var query = inputQuery;
            if(spec.Criteria != null) {
                query = query.Where(spec.Criteria);
            }

            if(spec.OrderBy != null) {
                query = query.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDecending != null) {
                query = query.OrderByDescending(spec.OrderByDecending);
            }

            if(spec.IsPaginationEnabled){
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes.Aggregate(query,(current, include) => current.Include(include));

            return query;
        }
    }
}