using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class ClientWorkoutRepository : IClientWorkoutRepository
    {
        private ApplicationDbContext _clientworkoutContext;
        public ClientWorkoutRepository(ApplicationDbContext context)
        {
            _clientworkoutContext = context;
        }

        public async Task<ClientWorkout> CreateAsync(ClientWorkout clientworkout)
        {
            _clientworkoutContext.Add(clientworkout);
            await _clientworkoutContext.SaveChangesAsync();
            return clientworkout;
        }

        public async Task<ClientWorkout> GetByIdAsync(int? id)
        {
            //eager loading
            return await _clientworkoutContext.ClientWorkouts.Include(c => c.ClientWorkoutWorkouts).Include(c => c.Avaliations).Include(c => c.DayOfTrains)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ClientWorkout>> GetClientWorkoutsAsync()
        {
            return await _clientworkoutContext.ClientWorkouts.ToListAsync();
        }

        public async Task<ClientWorkout> RemoveAsync(ClientWorkout clientworkout)
        {
            _clientworkoutContext.Remove(clientworkout);
            await _clientworkoutContext.SaveChangesAsync();
            return clientworkout;
        }

        public async Task<ClientWorkout> UpdateAsync(ClientWorkout clientworkout)
        {
            _clientworkoutContext.Update(clientworkout);
            await _clientworkoutContext.SaveChangesAsync();
            return clientworkout;
        }
    }
}

