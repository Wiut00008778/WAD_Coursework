using Microsoft.EntityFrameworkCore;
using Royality.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royality.DAL.Repository
{
    public class WatchRepository : BaseRepository, IRepository<Watch>
    {
        public WatchRepository(RoyalityDbContext context)
            : base(context) { }

        public async Task CreateAsync(Watch entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var watch = await _context.Watches.FindAsync(id);
            _context.Watches.Remove(watch);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Watches.Any(w => w.Id == id);
        }

        public async Task<List<Watch>> GetAllAsync()
        {
            return await _context.Watches.ToListAsync();
        }

        public async Task<Watch> GetByIdAsync(int id)
        {
            var watch = await _context.Watches.FindAsync(id);
            return await _context.Watches.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task UpdateAsync(Watch entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
