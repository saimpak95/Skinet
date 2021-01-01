﻿using Microsoft.EntityFrameworkCore;
using Skinet_Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skinet_Repository.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
     }
}