using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {

            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
              new Plan(1, "Plano pé rachado"),
              new Plan(2, "Plano Chique")
            );
        }
    }
}
