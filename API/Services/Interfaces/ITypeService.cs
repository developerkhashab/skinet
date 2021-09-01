using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Services.Interfaces
{
    public interface ITypeService
    {
        Task<IReadOnlyList<ProductType>> GetAllProductTypes();
    }
}