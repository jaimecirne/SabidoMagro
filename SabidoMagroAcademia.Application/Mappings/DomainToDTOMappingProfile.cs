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
            CreateMap<Activity, ActivityDTO>().ReverseMap();
            CreateMap<Avaliation, AvaliationDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<ClientWorkout, ClientWorkoutDTO>().ReverseMap();
            CreateMap<Contract, ContractDTO>().ReverseMap();
            CreateMap<DayOfTrain, DayOfTrainDTO>().ReverseMap();
            CreateMap<Manager, ManagerDTO>().ReverseMap();
            CreateMap<Resource, ResourceDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Workout, WorkoutDTO>().ReverseMap();

        }
    }
}
