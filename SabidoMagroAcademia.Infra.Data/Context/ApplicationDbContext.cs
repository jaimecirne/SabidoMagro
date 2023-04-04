using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Infra.Data.Identity;

namespace SabidoMagroAcademia.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Avaliation> Avaliations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientWorkout> ClientWorkouts { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<DayOfTrain> DayOfTrains { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
