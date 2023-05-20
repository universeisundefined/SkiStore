using System.Linq.Expressions;

namespace SkiStore.Core.Specifications
{
    public class BaseSpecifications<T> : ISpecifications<T>
    {
        public BaseSpecifications()
        {

        }
        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = 
            new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T,Object>> includeExpression){
            Includes.Add(includeExpression);
        }    
    }
}