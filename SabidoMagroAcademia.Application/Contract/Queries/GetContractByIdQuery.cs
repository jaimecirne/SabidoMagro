using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Queries
{
    public class GetContractByIdQuery : IRequest<Contract>
    {
        public int Id { get; set; }

        public GetContractByIdQuery(int id)
        {
            Id = id;
        }
    }
}
