

namespace Shared.Models
{
    public class SaleItemModel : BaseModel
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        //Navigation Properties
        public ProductModel? ProductModel { get; set; }
        public SaleModel? SaleModel { get; set; }
    }
}
