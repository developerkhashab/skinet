using System.Threading.Tasks;
using API.Services.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsBrandController : BaseApiController
    {
        private readonly IBrandService _bandService;
        public ProductsBrandController(IBrandService brandService)
        {
            _bandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<ProductBrand>> GetBrands()
        {
            var brands = await _bandService.GetAllProductBrands();
            return Ok(brands);
        }
    }
}