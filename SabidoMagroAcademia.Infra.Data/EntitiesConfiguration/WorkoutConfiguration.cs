using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Label).HasMaxLength(100).IsRequired();

            builder.HasMany(e => e.WorkoutActivities).WithOne(e => e.Workout);

            builder.HasData(
            new Workout(1, "Treino para Parte Anterior da Perna"));

        }
    }
}