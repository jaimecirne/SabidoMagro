using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class WorkoutActivityConfiguration : IEntityTypeConfiguration<WorkoutActivity>
    {
        public void Configure(EntityTypeBuilder<WorkoutActivity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(e => e.Workout).WithMany(e => e.WorkoutActivities);

            builder.HasData(new WorkoutActivity(1, 1, 3, 10, 1, 45, 1));

        }
    }
}