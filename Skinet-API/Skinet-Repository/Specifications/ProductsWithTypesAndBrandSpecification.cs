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
        public ProductsWithTypesAndBrandSpecification(string sort)
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandSpecification(int id) : base(x=>x.Id==id)
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }
    }
}
