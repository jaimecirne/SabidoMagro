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

            CreateMap<ActivityDTO, ActivityCreateCommand>();
            CreateMap<AvaliationDTO, AvaliationCreateCommand>();
            CreateMap<ClientDTO, ClientCreateCommand>();
            CreateMap<ClientWorkoutDTO, ClientWorkoutCreateCommand>();
            CreateMap<ContractDTO, ContractCreateCommand>();
            CreateMap<DayOfTrainDTO, DayOfTrainCreateCommand>();
            CreateMap<ManagerDTO, ManagerCreateCommand>();
            CreateMap<ResourceDTO, ResourceCreateCommand>();
            CreateMap<RoleDTO, RoleCreateCommand>();
            CreateMap<WorkoutDTO, WorkoutCreateCommand>();

            CreateMap<ActivityDTO, ActivityUpdateCommand>();
            CreateMap<AvaliationDTO, AvaliationUpdateCommand>();
            CreateMap<ClientDTO, ClientUpdateCommand>();
            CreateMap<ClientWorkoutDTO, ClientWorkoutUpdateCommand>();
            CreateMap<ContractDTO, ContractUpdateCommand>();
            CreateMap<DayOfTrainDTO, DayOfTrainUpdateCommand>();
            CreateMap<ManagerDTO, ManagerUpdateCommand>();
            CreateMap<ResourceDTO, ResourceUpdateCommand>();
            CreateMap<RoleDTO, RoleUpdateCommand>();
            CreateMap<WorkoutDTO, WorkoutUpdateCommand>();

        }
    }
}
