using FMS.Models.Main;
using FMS.Services.Common.Interfaces;
using FMS.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace FMS.Services.Common.DataServices
{
    public class JobStepDataService(AppDbContext context) : IDataService<JobStep>
    {
        private readonly AppDbContext _context = context;
        public async Task<JobStep> Create(JobStep entity)
        {
            var addedEntity = _context.JobSteps.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.JobSteps.FindAsync(id);
            if (entity != null)
            {
                _context.JobSteps.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<JobStep> Get(int id)
        {
            var entity = await _context.JobSteps.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<JobStep>> GetAll()
        {
            return await _context.JobSteps.ToListAsync();
        }
        public async Task<JobStep> Update(int id, JobStep entity)
        {
            var existingEntity = await _context.JobSteps.FindAsync(id);
            if (existingEntity != null)
            {
                existingEntity = entity;
            }
            else
            {
                await Create(entity);
                existingEntity = entity;
            }
            await _context.SaveChangesAsync();
            return existingEntity;
        }
    }
}
