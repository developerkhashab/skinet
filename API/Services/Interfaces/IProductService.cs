using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductToReturnView> GetProduct(int id);
        public Task<IReadOnlyList<ProductToReturnView>> GetProducts(string sort);
    }
}