using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private ApplicationDbContext _roleContext;
        public RoleRepository(ApplicationDbContext context)
        {
            _roleContext = context;
        }

        public async Task<Role> CreateAsync(Role role)
        {
            _roleContext.Add(role);
            await _roleContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> GetByIdAsync(int? id)
        {
            //eager loading
            return await _roleContext.Roles.Include(c => c.RoleWorkouts).Include(c => c.Avaliations).Include(c => c.DayOfTrains)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _roleContext.Roles.ToListAsync();
        }

        public async Task<Role> RemoveAsync(Role role)
        {
            _roleContext.Remove(role);
            await _roleContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            _roleContext.Update(role);
            await _roleContext.SaveChangesAsync();
            return role;
        }
    }
}

