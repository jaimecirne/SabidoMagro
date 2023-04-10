using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SabidoMagroAcademia.Application.Interfaces;
using SabidoMagroAcademia.Application.Mappings;
using SabidoMagroAcademia.Application.Services;
using SabidoMagroAcademia.Domain.Account;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;
using SabidoMagroAcademia.Infra.Data.Identity;
using SabidoMagroAcademia.Infra.Data.Repositories;
using System;

namespace SabidoMagroAcademia.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
             //define que os arquivos de migração irão ficar na pasta onde está definido o arquivo de contexto (Infra.Data)
             b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //Incluindo a configuração do Identity para users e roles
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()//inclui EF Core do Identity
                .AddDefaultTokenProviders();//adiciona provedor de token padrão
           
            //AddScoped é recomendação para aplicações web
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IPlanService, PlanService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            //necessário informar o nome do arquivo onde foram definidas as configurações do AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //registrando a DI dos handlers
            var myHandlers = AppDomain.CurrentDomain.Load("SabidoMagroAcademia.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
