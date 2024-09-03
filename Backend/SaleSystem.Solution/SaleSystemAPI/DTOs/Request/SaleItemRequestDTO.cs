namespace SaleSystemAPI.DTOs.Request
{
    public class SaleItemRequestDTO
    {
        public int ProductId { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
    }
}
