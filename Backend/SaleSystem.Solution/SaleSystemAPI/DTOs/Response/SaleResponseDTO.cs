namespace SaleSystemAPI.DTOs.Response
{
    public class SaleResponseDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public List<SaleItemResponseDTO> Items { get; set; } = new();
    }
}
