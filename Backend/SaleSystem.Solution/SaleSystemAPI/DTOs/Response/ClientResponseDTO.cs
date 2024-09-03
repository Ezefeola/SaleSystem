using SaleSystemAPI.Models;

namespace SaleSystemAPI.DTOs.Response
{
    public class ClientResponseDTO
    {
        public string Client { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = default!;
        public string EmailAddress { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<SaleModel>? Sales { get; set; }
    }
}
