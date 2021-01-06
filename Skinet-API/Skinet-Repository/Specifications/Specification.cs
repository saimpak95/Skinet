using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Skinet_Repository.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria { get;  }                         //Where clause
        List<Expression<Func<T,object>>> Includes { get; }                 //Include ProductBrand and ProductTypes
        Expression<Func<T,object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnable { get; }
    }
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
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

    public int Skip { get; private set; }

        public bool IsPagingEnable { get; private set; }

        protected void AddIncludes(Expression<Func<T,object>> expression)
        {
            Includes.Add(expression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> expression)
        {
            OrderBy = expression;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>> expression)
        {
            OrderByDescending = expression;
        }
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnable = true;
        }
    }
}
