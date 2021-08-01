using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using Core.Specifications;

namespace API.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductToReturnView> GetProduct(int id);
        public Task<Pagination<ProductToReturnView>> GetProducts(ProductSpecParams productParams);
    }
}