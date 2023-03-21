using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private ApplicationDbContext _planContext;
        public PlanRepository(ApplicationDbContext context)
        {
            _planContext = context;
        }

        public async Task<Plan> Create(Plan plan)
        {
            _planContext.Add(plan);
            await _planContext.SaveChangesAsync();
            return plan;
        }

        public async Task<Plan> GetById(int? id)
        {
            return await _planContext.Plans.FindAsync(id);
        }

        public async Task<IEnumerable<Plan>> GetPlans()
        {
            return await _planContext.Plans.ToListAsync();
        }

        public async Task<Plan> Remove(Plan plan)
        {
            _planContext.Remove(plan);
            await _planContext.SaveChangesAsync();
            return plan;
        }

        public async Task<Plan> Update(Plan plan)
        {
            _planContext.Update(plan);
            await _planContext.SaveChangesAsync();
            return plan;
        }
    }
}
