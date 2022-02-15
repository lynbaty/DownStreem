using System.Linq.Expressions;

namespace downstreem.Specifications
{
    public class BaseSpecification<T> : IBaseSpecification<T>
    {
        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public Expression<Func<T, bool>> Search { get; private set; }

        public List<Expression<Func<T, object>>> Includes { get; private set; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> Orderby { get; private set; }

        public Expression<Func<T, object>> OrderbyDesc { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderby(Expression<Func<T, object>> OrderbyExpression)
        {
            Orderby = OrderbyExpression;
        }

        protected void AddOrderbyDesc(Expression<Func<T, object>> OrderbyDescExpression)
        {
            OrderbyDesc = OrderbyDescExpression;
        }

        protected void AddSearch(Expression<Func<T, bool>> SearchExpression)
        {
            Search = SearchExpression;
        }
    }
}
