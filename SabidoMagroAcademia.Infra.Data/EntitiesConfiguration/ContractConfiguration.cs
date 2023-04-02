using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Start).HasColumnType("smalldatetime").IsRequired();
            builder.Property(p => p.End).HasColumnType("smalldatetime").IsRequired();
        }
    }
}