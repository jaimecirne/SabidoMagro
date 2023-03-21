using AutoMapper;
using SabidoMagroAcademia.Application.DTOs;
using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            //utiliza o ReverseMap para não precisar escrever o mapeamento reverso
            CreateMap<Plan, PlanDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
        }
    }
}
