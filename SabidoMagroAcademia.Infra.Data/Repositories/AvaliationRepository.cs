using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class AvaliationRepository : IAvaliationRepository
    {
        private ApplicationDbContext _avaliationContext;
        public AvaliationRepository(ApplicationDbContext context)
        {
            _avaliationContext = context;
        }

        public async Task<Avaliation> CreateAsync(Avaliation avaliation)
        {
            _avaliationContext.Add(avaliation);
            await _avaliationContext.SaveChangesAsync();
            return avaliation;
        }

        public async Task<Avaliation> GetByIdAsync(int? id)
        {
            return await _avaliationContext.Avaliations.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Avaliation>> GetAvaliationsAsync()
        {
            return await _avaliationContext.Avaliations.ToListAsync();
        }

        public async Task<Avaliation> RemoveAsync(Avaliation avaliation)
        {
            _avaliationContext.Remove(avaliation);
            await _avaliationContext.SaveChangesAsync();
            return avaliation;
        }

        public async Task<Avaliation> UpdateAsync(Avaliation avaliation)
        {
            _avaliationContext.Update(avaliation);
            await _avaliationContext.SaveChangesAsync();
            return avaliation;
        }
    }
}

