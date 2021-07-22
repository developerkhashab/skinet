using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecifications : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecifications(string sort)
        {
            AddInclude( x=> x.ProductType);
            AddInclude( x=> x.ProductBrand);

            if(!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
            else AddOrderBy(x => x.Name);
        }
        public ProductsWithTypesAndBrandsSpecifications(int id) : base(x =>x.Id == id)
        {
            AddInclude( x=> x.ProductType);
            AddInclude( x=> x.ProductBrand);
        }
    }
}