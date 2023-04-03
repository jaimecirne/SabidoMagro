using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class DayOfTrainRepository : IDayOfTrainRepository
    {
        private ApplicationDbContext _dayoftrainContext;
        public DayOfTrainRepository(ApplicationDbContext context)
        {
            _dayoftrainContext = context;
        }

        public async Task<DayOfTrain> CreateAsync(DayOfTrain dayoftrain)
        {
            _dayoftrainContext.Add(dayoftrain);
            await _dayoftrainContext.SaveChangesAsync();
            return dayoftrain;
        }

        public async Task<DayOfTrain> GetByIdAsync(int? id)
        {
            //eager loading
            return await _dayoftrainContext.DayOfTrains.Include(c => c.DayOfTrainWorkouts).Include(c => c.Avaliations).Include(c => c.DayOfTrains)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<DayOfTrain>> GetDayOfTrainsAsync()
        {
            return await _dayoftrainContext.DayOfTrains.ToListAsync();
        }

        public async Task<DayOfTrain> RemoveAsync(DayOfTrain dayoftrain)
        {
            _dayoftrainContext.Remove(dayoftrain);
            await _dayoftrainContext.SaveChangesAsync();
            return dayoftrain;
        }

        public async Task<DayOfTrain> UpdateAsync(DayOfTrain dayoftrain)
        {
            _dayoftrainContext.Update(dayoftrain);
            await _dayoftrainContext.SaveChangesAsync();
            return dayoftrain;
        }
    }
}

