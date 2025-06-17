using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithTpyesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTpyesAndBrandsSpecification(string sort, int? brandId, int? typeId):base(
            x=>(!brandId.HasValue || x.ProductBrandId == brandId)&&
               (!typeId.HasValue || x.ProductTypeId == typeId)
        )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    case "name":
                        AddOrderBy(x => x.Name);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductWithTpyesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
