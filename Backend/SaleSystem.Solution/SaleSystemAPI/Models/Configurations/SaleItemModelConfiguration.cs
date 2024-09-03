using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaleSystemAPI.Models.Configurations
{
    public class SaleItemModelConfiguration : EntityTypeBaseConfiguration<SaleItemModel>
    {
        protected override void ConfigurateConstrains(EntityTypeBuilder<SaleItemModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ProductModel).WithMany(x => x.SaleItemModel).HasForeignKey(x => x.ProductId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<SaleItemModel> builder)
        {

        }

        protected override void ConfigurateTableName(EntityTypeBuilder<SaleItemModel> builder)
        {
            builder.ToTable("SalesItems");
        }
    }
}
