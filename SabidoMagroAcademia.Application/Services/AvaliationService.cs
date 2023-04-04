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
    public class AvaliationService : IAvaliationService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;//utiliza essa instância para enviar os requests para os handles
        public AvaliationService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<AvaliationDTO>> GetAvaliations()
        {
            var avaliationsQuery = new GetAvaliationsQuery();

            if (avaliationsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            //envia-se o tipo de handler através do .Send para ser executado
            var result = await _mediator.Send(avaliationsQuery);

            //necessário mapear o retorno para DTO
            return _mapper.Map<IEnumerable<AvaliationDTO>>(result);
        }

        public async Task<AvaliationDTO> GetById(int? id)
        {
            var avaliationByIdQuery = new GetAvaliationByIdQuery(id.Value);

            if (avaliationByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(avaliationByIdQuery);

            return _mapper.Map<AvaliationDTO>(result);
        }

        public async Task Add(AvaliationDTO avaliationDto)
        {
            //realiza o mapeamento da classe DTO para classe command
            var avaliationCreateCommand = _mapper.Map<AvaliationCreateCommand>(avaliationDto);
            //através do tipo de classe command informada o mediator sabe qual handler chamar
            await _mediator.Send(avaliationCreateCommand);
        }

        public async Task Update(AvaliationDTO avaliationDto)
        {
            var avaliationUpdateCommand = _mapper.Map<AvaliationUpdateCommand>(avaliationDto);
            await _mediator.Send(avaliationUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var avaliationRemoveCommand = new AvaliationRemoveCommand(id.Value);
            if (avaliationRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(avaliationRemoveCommand);
        }
    }
}
