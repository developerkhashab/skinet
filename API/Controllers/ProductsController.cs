using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using API.Services.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductsController(IGenericRepository<Product> productsRepo, IMapper mapper, IProductService productService)
        {
            _productService = productService;
            _mapper = mapper;
            _productsRepo = productsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnView>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var products = await _productService.GetProducts(productParams);
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnView>> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null) return NotFound(new ApiResponse(404));
            return Ok(product);
        }
    }
}