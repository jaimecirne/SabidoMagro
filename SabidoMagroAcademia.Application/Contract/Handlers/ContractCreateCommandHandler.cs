using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ContractCreateCommandHandler : IRequestHandler<ContractCreateCommand, Contract>
    {
        private readonly IContractRepository _contractRepository;
        public ContractCreateCommandHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository ?? throw new
                ArgumentNullException(nameof(contractRepository));
        }
        public async Task<Contract> Handle(ContractCreateCommand request,
            CancellationToken cancellationToken)
        {
            var contract = new Contract(request.User);
            
            if (contract == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _contractRepository.CreateAsync(contract);
            }
        }
    }
}
