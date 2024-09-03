namespace SaleSystemAPI.Models
{
    public class CategoryModel : BaseModel
    {
        public string Name { get; set; } = default!;

        //Navigation Properties 
        public List<ProductModel>? ProductModel { get; set; }
    }
}
