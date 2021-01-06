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
        public ProductsWithTypesAndBrandSpecification(ProductSpecificationParams productParams)
            :base(x=> (!productParams.BrandID.HasValue || x.ProductBrandID== productParams.BrandID) && (!productParams.TypeID.HasValue || x.ProductTypeID == productParams.TypeID))
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
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
