using System;
using System.Collections.Generic;
using System.Text;

namespace Royality.DAL.Repository
{
    public abstract class BaseRepository
    {
        protected readonly RoyalityDbContext _context;

        protected BaseRepository(RoyalityDbContext context)
        {
            _context = context;
        }
    }
}
