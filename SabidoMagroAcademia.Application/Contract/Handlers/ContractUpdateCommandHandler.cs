using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ContractUpdateCommandHandler : IRequestHandler<ContractUpdateCommand, Contract>
    {
        private readonly IContractRepository _contractRepository;
        public ContractUpdateCommandHandler(IContractRepository productRepository)
        {
            _contractRepository = productRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Contract> Handle(ContractUpdateCommand request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.GetByIdAsync(request.Id);

            if (contract == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                contract.Update(request.Id, request.Plan, request.Client, request.TotalPrice, request.Start, request.End, request.Active);
                return await _contractRepository.UpdateAsync(contract);
            }

        }
    }
}
