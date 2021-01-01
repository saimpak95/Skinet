﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Skinet_Repository.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria { get;  }                         //Where clause
        List<Expression<Func<T,object>>> Includes { get; }                 //Include ProductBrand and ProductTypes
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

        protected void AddIncludes(Expression<Func<T,object>> expression)
        {
            Includes.Add(expression);
        }
    }
}
