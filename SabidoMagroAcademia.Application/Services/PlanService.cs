using AutoMapper;
using SabidoMagroAcademia.Application.DTOs;
using SabidoMagroAcademia.Application.Interfaces;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Services
{
    public class planService : IPlanService
    {
        private IPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public planService(IPlanRepository planRepository, IMapper mapper)
        {
            _planRepository = planRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlanDTO>> GetCategories()
        {
            var plansEntity = await _planRepository.GetPlans();//retorta lista de objetos da entidade
            return _mapper.Map<IEnumerable<PlanDTO>>(plansEntity);//faz o mapeamento da entidade para o DTO
        }

        public async Task<PlanDTO> GetById(int? id)
        {
            var planEntity = await _planRepository.GetById(id);
            return _mapper.Map<PlanDTO>(planEntity);
        }

        public async Task Add(PlanDTO planDto)
        {
            var planEntity = _mapper.Map<Plan>(planDto);//faz o mapeamento reverso DTO/entidade
            await _planRepository.Create(planEntity);
        }

        public async Task Update(PlanDTO planDto)
        {
            var planEntity = _mapper.Map<Plan>(planDto);
            await _planRepository.Update(planEntity);
        }

        public async Task Remove(int? id)
        {
            //Utilizando o .Result para receber um objeto plan em vez de um Task<plan>
            var planEntity = _planRepository.GetById(id).Result;
            await _planRepository.Remove(planEntity);
        }

    }
}
