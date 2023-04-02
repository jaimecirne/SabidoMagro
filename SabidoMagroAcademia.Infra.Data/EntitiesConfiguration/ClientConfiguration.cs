﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(t => t.Id);

            //configura um relacionamento um para muitos entre plan e Products
            builder.HasMany(e => e.DayOfTrains).WithOne();
        }
    }
}