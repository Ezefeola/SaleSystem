using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaleSystemAPI.Models.Configurations
{
    public class SaleModelConfiguration : EntityTypeBaseConfiguration<SaleModel>
    {
        protected override void ConfigurateConstrains(EntityTypeBuilder<SaleModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.SaleItemModel).WithOne(c => c.SaleModel).HasForeignKey(x => x.SaleId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<SaleModel> builder)
        {

        }

        protected override void ConfigurateTableName(EntityTypeBuilder<SaleModel> builder)
        {
            builder.ToTable("Sales");
        }
    }
}
