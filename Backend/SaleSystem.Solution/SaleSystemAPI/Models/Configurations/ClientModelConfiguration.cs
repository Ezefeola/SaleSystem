using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaleSystemAPI.Models.Configurations
{
    public class ClientModelConfiguration : EntityTypeBaseConfiguration<ClientModel>
    {
        protected override void ConfigurateConstrains(EntityTypeBuilder<ClientModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.SaleModel).WithOne(x => x.ClientModel).HasForeignKey(x => x.ClientId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<ClientModel> builder)
        {
            builder.Property(c => c.Client).IsRequired().HasMaxLength(250);
            builder.Property(c => c.PhoneNumber).HasMaxLength(10);
            builder.Property(c => c.EmailAddress).HasMaxLength(250);
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<ClientModel> builder)
        {
            builder.ToTable("Clients");
        }
    }
}
