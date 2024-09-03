namespace SaleSystemAPI.DTOs.Request
{
    public class SaleRequestDTO
    {
        public int ClientId { get; set; }
        public List<SaleItemRequestDTO> Items { get; set; } = new();
    }
}
