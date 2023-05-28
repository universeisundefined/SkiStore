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

        public Expression<Func<T, object>> OrderBy {get; private set;}

        public Expression<Func<T, object>> OrderByDecending {get; private set;}

        public int Take {get; private set;}

        public int Skip {get; private set;}

        public bool IsPaginationEnabled {get; private set;}

        protected void AddInclude(Expression<Func<T,Object>> includeExpression){
            Includes.Add(includeExpression);
        }    

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression){
            OrderBy = orderByExpression;
        }

         protected void AddOrderByDecending(Expression<Func<T, object>> orderByDescExpression){
            OrderByDecending = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take){
            Skip = skip;
            Take = take;
            IsPaginationEnabled = true;
        }
    }
}