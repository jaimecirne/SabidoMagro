using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Fone).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Image).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Gender).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Born).HasColumnType("smalldatetime").IsRequired();
        }
    }
}