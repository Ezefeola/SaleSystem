
namespace Shared.Models
{
    public class SaleModel : BaseModel
    {
        public int ClientId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Total { get; set; }

        // Navigation Properties
        public ICollection<SaleItemModel>? SaleItemModel { get; set; }
        public ClientModel? ClientModel { get; set; }
    }
}
