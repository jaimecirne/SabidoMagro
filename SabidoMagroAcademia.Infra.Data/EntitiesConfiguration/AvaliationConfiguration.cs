using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class AvaliationConfiguration : IEntityTypeConfiguration<Avaliation>
    {
        public void Configure(EntityTypeBuilder<Avaliation> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Label).HasMaxLength(100).IsRequired();
            builder.Property(p => p.CoachsComments).HasMaxLength(500).IsRequired();

            builder.Property(p => p.Weight).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Height).IsRequired();


            builder.HasOne(e => e.Client).WithMany(e => e.Avaliations)
                .HasForeignKey(e => e.ClientId);
            builder.HasOne(e => e.Coach).WithMany(e => e.Avaliations)
                .HasForeignKey(e => e.CoachId);
        }
    }
}