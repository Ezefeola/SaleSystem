namespace Shared.DTOs.Request
{
    public class SaleRequestDTO
    {
        public int ClientId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public List<SaleItemRequestDTO> Items { get; set; } = new();
    }
}
