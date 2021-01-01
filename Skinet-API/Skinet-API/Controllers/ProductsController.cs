using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet_DomainModels;
using Microsoft.EntityFrameworkCore;
using Skinet_Repository;
using Skinet_Repository.Specifications;
using Skinet_DTO;
using AutoMapper;

namespace Skinet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IGenericRepository<Product> ProductRepository;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> ProductRepository, IMapper mapper)
        {
            this.ProductRepository = ProductRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandSpecification();
            var products = await ProductRepository.GetListWithSpecification(spec);
            return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandSpecification(id);
            var product = await ProductRepository.GetEntityWithSpecification(spec);
            return mapper.Map<Product, ProductToReturnDTO>(product);
        }
    }
}
