using Skinet_DomainModels;
using Skinet_Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Skinet_Repository.Specifications
{
   public class ProductsWithTypesAndBrandSpecification   :BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandSpecification()
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }

        public ProductsWithTypesAndBrandSpecification(int id) : base(x=>x.Id==id)
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }
    }
}
