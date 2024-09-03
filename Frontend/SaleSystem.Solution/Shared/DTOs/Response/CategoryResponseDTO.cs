using Shared.Models;

namespace Shared.DTOs.Response
{
    public class CategoryResponseDTO : BaseModel
    {
        public string Name { get; set; } = default!;
    }
}
