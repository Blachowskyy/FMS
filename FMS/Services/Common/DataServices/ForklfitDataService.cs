using FMS.Models.Main;
using FMS.Services.Common.Interfaces;
using FMS.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace FMS.Services.Common.DataServices
{
    public class ForklfitDataService(AppDbContext context) : IDataService<Forklift>
    {
        private readonly AppDbContext _context = context;

        public async Task<Forklift> Create(Forklift entity)
        {
            var addedEntity = _context.Forklifts.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Forklifts.FindAsync(id);
            if (entity != null)
            {
                _context.Forklifts.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Forklift> Get(int id)
        {
            var entity = await _context.Forklifts.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Forklift>> GetAll()
        {
            return await _context.Forklifts.ToListAsync();
        }

        public async Task<Forklift> Update(int id, Forklift entity)
        {
            var existingEntity = await _context.Forklifts.FindAsync(id);
            if (existingEntity != null)
            {
                existingEntity = entity;
                await _context.SaveChangesAsync();
                return existingEntity;
            }
            throw new NotImplementedException();
        }
    }
}
