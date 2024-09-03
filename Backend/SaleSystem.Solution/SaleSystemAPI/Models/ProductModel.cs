using Microsoft.EntityFrameworkCore;

namespace SaleSystemAPI.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        //Navigation Properties
        public List<SaleItemModel>? SaleItemModel { get; set; }

        public CategoryModel? CategoryModel { get; set; }
    }
}
