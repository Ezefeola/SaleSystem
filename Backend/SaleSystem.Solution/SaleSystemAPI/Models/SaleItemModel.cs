using Microsoft.EntityFrameworkCore;

namespace SaleSystemAPI.Models
{
    public class SaleItemModel : BaseModel
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }

        [Precision(18,2)]
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }

        //Navigation Properties
        public ProductModel? ProductModel { get; set; }
        public SaleModel? SaleModel { get; set; }
    }
}
