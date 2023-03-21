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
    /*
        * 
        * Classe responsável por tratar das injeções de dependências do projeto.
        * Faz o registro das entidades mapeando interface / classe concreta.
        * Cross cuting, expõe os serviços que podem ser utilizado em qualquer parte do projeto
        * 
        * **/
    public static class DependencyInjection
    {
        /*
         * 
         *Trata-se método de extenção, adiciona funcionalidades a um tipo já existente
         * que neste caso é a interface IServiceCollection. O mesmo deve ser static
         * assim como a classe.
         * 
         * **/
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
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

            //Configuração do cookie
            //quando o user não tiver acesso a algum recurso, redireciona para fazer login
            services.ConfigureApplicationCookie(options =>
                     options.AccessDeniedPath = "/Account/Login");

            //AddScoped é recomendação para aplicações web
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IPlanService, planService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();


            //necessário informar o nome do arquivo onde foram definidas as configurações do AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //registrando a DI dos handlers
            var myHandlers = AppDomain.CurrentDomain.Load("SabidoMagroAcademia.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
