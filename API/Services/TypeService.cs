using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace API.Services
{
    public class TypeService : ITypeService
    {
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        public TypeService(IGenericRepository<ProductType> productTypeRepo)
        {
            _productTypeRepo = productTypeRepo;
        }

        public Task<IReadOnlyList<ProductType>> GetAllProductTypes()
        {
            return _productTypeRepo.ListAllAsync();
        }
    }
}