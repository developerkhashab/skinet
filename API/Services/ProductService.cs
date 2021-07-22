using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Services.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> productsRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productsRepo = productsRepo;
        }

        public async Task<IReadOnlyList<ProductToReturnView>> GetProducts(string sort)
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications(sort);
            var products = await _productsRepo.ListAsync(spec);
            return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnView>>(products);
        }

        public async Task<ProductToReturnView> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            if(product == null ) return null; 
            return _mapper.Map<Product, ProductToReturnView>(product);
        }
    }
}