using FMS.Models.Main;
using FMS.Services.Common.Interfaces;
using FMS.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Services.Common.DataServices
{
    public class LocationDataService(AppDbContext context) : IDataService<Location>
    {
        private readonly AppDbContext _context = context;
        public async Task<Location> Create(Location entity)
        {
            var addedEntity = _context.Locations.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Locations.FindAsync(id);
            if (entity != null)
            {
                _context.Locations.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Location> Get(int id)
        {
            var entity = await _context.Locations.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Location>> GetAll()
        {
            return await _context.Locations.ToListAsync();
        }
        public async Task<Location> Update(int id, Location entity)
        {
            var existingEntity = await _context.Locations.FindAsync(id);
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
