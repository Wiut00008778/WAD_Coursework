using Microsoft.EntityFrameworkCore;
using Royality.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royality.DAL.Repository
{
    public class ManufacturerRepository : BaseRepository, IRepository<Manufacturer>
    {
        public ManufacturerRepository(RoyalityDbContext context)
            : base(context)
        {
        }

        public async Task CreateAsync(Manufacturer entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Manufacturers.Any(m => m.Id == id);
        }

        public async Task<List<Manufacturer>> GetAllAsync()
        {
            return await _context.Manufacturers.ToListAsync();
        }

        public async Task<Manufacturer> GetByIdAsync(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            return await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Manufacturer entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
