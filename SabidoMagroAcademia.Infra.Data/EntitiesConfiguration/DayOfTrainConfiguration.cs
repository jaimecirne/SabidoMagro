using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class DayOfTrainConfiguration : IEntityTypeConfiguration<DayOfTrain>
    {
        public void Configure(EntityTypeBuilder<DayOfTrain> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Day).HasColumnType("smalldatetime").IsRequired();


        }
    }
}