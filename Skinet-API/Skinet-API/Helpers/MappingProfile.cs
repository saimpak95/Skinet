using AutoMapper;
using Skinet_DomainModels;
using Skinet_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet_API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(dest=>dest.ProductBrand, option=>option.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(dest=>dest.ProductType, option=>option.MapFrom(s=>s.ProductType.Name))
                .ForMember(dest=>dest.PictureUrl, option=>option.MapFrom<ProductUrlResolver>());

        }
    }
}
