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
    public class PlanService : IPlanService
    {
        private IPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public PlanService(IPlanRepository planRepository, IMapper mapper)
        {
            _planRepository = planRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlanDTO>> GetPlans()
        {
            var plansEntity = await _planRepository.GetPlans();
            return _mapper.Map<IEnumerable<PlanDTO>>(plansEntity);
        }

        public async Task<PlanDTO> GetById(int? id)
        {
            var planEntity = await _planRepository.GetById(id);
            return _mapper.Map<PlanDTO>(planEntity);
        }

        public async Task Add(PlanDTO planDto)
        {
            var planEntity = _mapper.Map<Plan>(planDto);
            await _planRepository.Create(planEntity);
        }

        public async Task Update(PlanDTO planDto)
        {
            var planEntity = _mapper.Map<Plan>(planDto);
            await _planRepository.Update(planEntity);
        }

        public async Task Remove(int? id)
        {
            var planEntity = _planRepository.GetById(id).Result;
            await _planRepository.Remove(planEntity);
        }

    }
}
