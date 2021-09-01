using System.Threading.Tasks;
using API.Services.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsTypeController : BaseApiController
    {
        private readonly ITypeService _typeService;
        public ProductsTypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<ActionResult<ProductType>> GetTypes()
        {
            var types = await _typeService.GetAllProductTypes();
            return Ok(types);
        }
    }
}