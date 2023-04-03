using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private ApplicationDbContext _activityContext;
        public ActivityRepository(ApplicationDbContext context)
        {
            _activityContext = context;
        }

        public async Task<Activity> CreateAsync(Activity activity)
        {
            _activityContext.Add(activity);
            await _activityContext.SaveChangesAsync();
            return activity;
        }

        public async Task<Activity> GetByIdAsync(int? id)
        {
            //eager loading
            return await _activityContext.Activities.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Activity>> GetActivitysAsync()
        {
            return await _activityContext.Activities.ToListAsync();
        }

        public async Task<Activity> RemoveAsync(Activity activity)
        {
            _activityContext.Remove(activity);
            await _activityContext.SaveChangesAsync();
            return activity;
        }

        public async Task<Activity> UpdateAsync(Activity activity)
        {
            _activityContext.Update(activity);
            await _activityContext.SaveChangesAsync();
            return activity;
        }
    }
}

