
using Shared.Models;

namespace Shared.DTOs.Response
{
    public class ProductResponseDTO : BaseModel
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        //Navigation Properties
        //public ICollection<SaleItemModel>? SaleItemModel { get; set; }

        //public CategoryModel? CategoryModel { get; set; }
    }
}
