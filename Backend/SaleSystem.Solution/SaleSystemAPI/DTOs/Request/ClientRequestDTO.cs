using SaleSystemAPI.Models;

namespace SaleSystemAPI.DTOs.Request
{
    public class ClientRequestDTO
    {
        public string Client { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;

    }
}
