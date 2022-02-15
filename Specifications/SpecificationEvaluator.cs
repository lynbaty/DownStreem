using downstreem.Models;
using Microsoft.EntityFrameworkCore;

namespace downstreem.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery (IQueryable<TEntity> inputQuery, IBaseSpecification<TEntity> spec)
        {
            var query = inputQuery;

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if(spec.Search != null)
            {
                query = query.Where(spec.Search);
            }    

            if(spec.Orderby != null)
            {
                query = query.OrderBy(spec.Orderby);
            }    

            if(spec.OrderbyDesc != null)
            {
                query = query.OrderByDescending(spec.OrderbyDesc);
            }    

            if(spec.Includes.Count > 0)
            {
                foreach(var include in spec.Includes)
                {
                    query = query.Include(include);
                }    
            }  
            
            return query;
        }
    }
}
