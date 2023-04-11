using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private ApplicationDbContext _workoutContext;
        public WorkoutRepository(ApplicationDbContext context)
        {
            _workoutContext = context;
        }

        public async Task<Workout> CreateAsync(Workout workout)
        {
            _workoutContext.Add(workout);
            await _workoutContext.SaveChangesAsync();
            return workout;
        }

        public async Task<Workout> GetByIdAsync(int? id)
        {
            return await _workoutContext.Workouts.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsAsync()
        {
            return await _workoutContext.Workouts.ToListAsync();
        }

        public async Task<Workout> RemoveAsync(Workout workout)
        {
            _workoutContext.Remove(workout);
            await _workoutContext.SaveChangesAsync();
            return workout;
        }

        public async Task<Workout> UpdateAsync(Workout workout)
        {
            _workoutContext.Update(workout);
            await _workoutContext.SaveChangesAsync();
            return workout;
        }
    }
}

