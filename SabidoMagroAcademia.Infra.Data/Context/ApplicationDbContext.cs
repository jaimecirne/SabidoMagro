﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        //Mapeamento
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Client> Clients { get; set; }

        //método permite configurar o modelo usando a Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //utlizando para refenciar automaticamente todas as entidades criadas nas classes de EntitiesConfigurations
            //desse forma não precisa instanciar um por um (ex. builder.ApplyConfigurations(new ProductConfiguation();)
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
