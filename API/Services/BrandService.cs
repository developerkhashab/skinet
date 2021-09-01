using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace API.Services
{
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        public BrandService(IGenericRepository<ProductBrand> productBrandRepo)
        {
            _productBrandRepo = productBrandRepo;
        }

        public Task<IReadOnlyList<ProductBrand>> GetAllProductBrands()
        {
            return _productBrandRepo.ListAllAsync();
        }
    }
}