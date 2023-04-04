using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private ApplicationDbContext _managerContext;
        public ManagerRepository(ApplicationDbContext context)
        {
            _managerContext = context;
        }

        public async Task<Manager> CreateAsync(Manager manager)
        {
            _managerContext.Add(manager);
            await _managerContext.SaveChangesAsync();
            return manager;
        }

        public async Task<Manager> GetByIdAsync(int? id)
        {
            return await _managerContext.Managers.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Manager>> GetManagersAsync()
        {
            return await _managerContext.Managers.ToListAsync();
        }

        public async Task<Manager> RemoveAsync(Manager manager)
        {
            _managerContext.Remove(manager);
            await _managerContext.SaveChangesAsync();
            return manager;
        }

        public async Task<Manager> UpdateAsync(Manager manager)
        {
            _managerContext.Update(manager);
            await _managerContext.SaveChangesAsync();
            return manager;
        }
    }
}

