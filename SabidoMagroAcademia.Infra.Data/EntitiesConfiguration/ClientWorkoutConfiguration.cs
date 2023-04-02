using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class ClientWorkoutConfiguration : IEntityTypeConfiguration<ClientWorkout>
    {
        public void Configure(EntityTypeBuilder<ClientWorkout> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(e => e.Client).WithMany(e => e.ClientWorkouts)
                .HasForeignKey(e => e.ClientId);
            
            builder.HasOne(e => e.Coach).WithMany(e => e.ClientWorkouts);
        }
    }
}