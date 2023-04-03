using AutoMapper;
using MediatR;
using SabidoMagroAcademia.Application.DTOs;
using SabidoMagroAcademia.Application.Interfaces;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Application.Products.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Services
{
    public class DayOfTrainService : IDayOfTrainService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;//utiliza essa instância para enviar os requests para os handles
        public DayOfTrainService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<DayOfTrainDTO>> GetDayOfTrains()
        {
            var dayoftrainsQuery = new GetDayOfTrainsQuery();

            if (dayoftrainsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            //envia-se o tipo de handler através do .Send para ser executado
            var result = await _mediator.Send(dayoftrainsQuery);

            //necessário mapear o retorno para DTO
            return _mapper.Map<IEnumerable<DayOfTrainDTO>>(result);
        }

        public async Task<DayOfTrainDTO> GetById(int? id)
        {
            var dayoftrainByIdQuery = new GetDayOfTrainByIdQuery(id.Value);

            if (dayoftrainByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(dayoftrainByIdQuery);

            return _mapper.Map<DayOfTrainDTO>(result);
        }

        public async Task Add(DayOfTrainDTO dayoftrainDto)
        {
            //realiza o mapeamento da classe DTO para classe command
            var dayoftrainCreateCommand = _mapper.Map<DayOfTrainCreateCommand>(dayoftrainDto);
            //através do tipo de classe command informada o mediator sabe qual handler chamar
            await _mediator.Send(dayoftrainCreateCommand);
        }

        public async Task Update(DayOfTrainDTO dayoftrainDto)
        {
            var dayoftrainUpdateCommand = _mapper.Map<DayOfTrainUpdateCommand>(dayoftrainDto);
            await _mediator.Send(dayoftrainUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var dayoftrainRemoveCommand = new DayOfTrainRemoveCommand(id.Value);
            if (dayoftrainRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(dayoftrainRemoveCommand);
        }
    }
}
