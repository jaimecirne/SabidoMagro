using AutoMapper;
using SabidoMagroAcademia.Application.DTOs;
using SabidoMagroAcademia.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Mappings
{
    class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ClientDTO, ClientCreateCommand>();
            CreateMap<ClientDTO, ClientUpdateCommand>();
        }
    }
}
