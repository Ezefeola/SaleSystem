using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaleSystemAPI.Models.Configurations
{
    public class CategoryModelConfiguration : EntityTypeBaseConfiguration<CategoryModel>
    {
        protected override void ConfigurateConstrains(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ProductModel).WithOne(x => x.CategoryModel).HasForeignKey(x => x.CategoryId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(250);
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.ToTable("Categories");
        }
    }
}
