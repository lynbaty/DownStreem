using System.Linq.Expressions;

namespace downstreem.Specifications
{
    public interface IBaseSpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> Orderby { get; }
        Expression<Func<T, object>> OrderbyDesc { get; }
        Expression<Func<T, bool>> Search { get; }
    }
}