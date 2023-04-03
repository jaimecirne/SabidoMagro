using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private ApplicationDbContext _resourceContext;
        public ResourceRepository(ApplicationDbContext context)
        {
            _resourceContext = context;
        }

        public async Task<Resource> CreateAsync(Resource resource)
        {
            _resourceContext.Add(resource);
            await _resourceContext.SaveChangesAsync();
            return resource;
        }

        public async Task<Resource> GetByIdAsync(int? id)
        {
            //eager loading
            return await _resourceContext.Resources.Include(c => c.ResourceWorkouts).Include(c => c.Avaliations).Include(c => c.DayOfTrains)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Resource>> GetResourcesAsync()
        {
            return await _resourceContext.Resources.ToListAsync();
        }

        public async Task<Resource> RemoveAsync(Resource resource)
        {
            _resourceContext.Remove(resource);
            await _resourceContext.SaveChangesAsync();
            return resource;
        }

        public async Task<Resource> UpdateAsync(Resource resource)
        {
            _resourceContext.Update(resource);
            await _resourceContext.SaveChangesAsync();
            return resource;
        }
    }
}

