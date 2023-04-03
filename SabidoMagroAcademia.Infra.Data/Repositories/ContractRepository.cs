using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private ApplicationDbContext _contractContext;
        public ContractRepository(ApplicationDbContext context)
        {
            _contractContext = context;
        }

        public async Task<Contract> CreateAsync(Contract contract)
        {
            _contractContext.Add(contract);
            await _contractContext.SaveChangesAsync();
            return contract;
        }

        public async Task<Contract> GetByIdAsync(int? id)
        {
            //eager loading
            return await _contractContext.Contracts.Include(c => c.ContractWorkouts).Include(c => c.Avaliations).Include(c => c.DayOfTrains)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Contract>> GetContractsAsync()
        {
            return await _contractContext.Contracts.ToListAsync();
        }

        public async Task<Contract> RemoveAsync(Contract contract)
        {
            _contractContext.Remove(contract);
            await _contractContext.SaveChangesAsync();
            return contract;
        }

        public async Task<Contract> UpdateAsync(Contract contract)
        {
            _contractContext.Update(contract);
            await _contractContext.SaveChangesAsync();
            return contract;
        }
    }
}

