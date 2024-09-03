namespace SaleSystemAPI.DTOs.Response
{
    public class SaleItemResponseDTO
    {
        public int ProductId { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
