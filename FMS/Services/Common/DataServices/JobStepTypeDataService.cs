using FMS.Models.Main;
using FMS.Services.Common.Interfaces;
using FMS.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace FMS.Services.Common.DataServices
{
    public class JobStepTypeDataService(AppDbContext context) : IDataService<JobStepType>
    {
        private readonly AppDbContext _context = context;
        public async Task<JobStepType> Create(JobStepType entity)
        {
            var addedEntity = _context.JobStepTypes.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.JobStepTypes.FindAsync(id);
            if (entity != null)
            {
                _context.JobStepTypes.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<JobStepType> Get(int id)
        {
            var entity = await _context.JobStepTypes.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<JobStepType>> GetAll()
        {
            return await _context.JobStepTypes.ToListAsync();
        }
        public async Task<JobStepType> Update(int id, JobStepType entity)
        {
            var existingEntity = await _context.JobStepTypes.FindAsync(id);
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
