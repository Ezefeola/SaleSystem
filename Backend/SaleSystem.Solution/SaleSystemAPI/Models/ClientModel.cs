using System.ComponentModel.DataAnnotations;

namespace SaleSystemAPI.Models
{
    public class ClientModel : BaseModel
    {
        public string Client { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = default!;

        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<SaleModel>? SaleModel { get; set; }
    }
}
