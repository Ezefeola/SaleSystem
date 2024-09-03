using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaleSystemAPI.Models.Configurations
{
    public class ProductModelConfiguration : EntityTypeBaseConfiguration<ProductModel>
    {
        protected override void ConfigurateConstrains(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(c => c.CategoryModel).WithMany(p => p.ProductModel).HasForeignKey(x => x.CategoryId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<ProductModel> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Price).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(255);
            builder.Property(p => p.CategoryId).IsRequired();
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("Products");
        }
    }
}
