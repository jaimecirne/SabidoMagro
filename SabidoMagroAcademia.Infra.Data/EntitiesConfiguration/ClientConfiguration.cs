using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

            //definindo precisão do atributo, 10 posições e 2 casas decimais
            builder.Property(p => p.Weight).HasPrecision(10, 2);

            //configura um relacionamento um para muitos entre plan e Products
            builder.HasOne(e => e.Plan).WithMany(e => e.Clients)
                .HasForeignKey(e => e.PlanId);
        }
    }
}