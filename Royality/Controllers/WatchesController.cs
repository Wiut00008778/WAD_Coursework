using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Royality.DAL;
using Royality.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Royality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchesController : ControllerBase
    {
        private readonly RoyalityDbContext _context;

        public WatchesController(RoyalityDbContext context)
        {
            _context = context;
        }
        // GET: api/<WatchesController>
        [HttpGet]
        public IEnumerable<Watch> GetWatches(int? manufacturerId)
        {
            return _context.Watches.Include("Manufacturer").Where(p => manufacturerId == null || p.ManufacturerId == manufacturerId.Value);
        }

        // GET api/<WatchesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWatch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var watch = await _context.Watches.FindAsync(id);

            if (watch == null)
            {
                return NotFound();
            }

            return Ok(watch);
        }

        // POST api/<WatchesController>
        [HttpPost]
        public async Task<IActionResult> PostWatch([FromBody] Watch watch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Watches.Add(watch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatch", new { id = watch.Id }, watch);
        }

        // PUT api/<WatchesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatch([FromRoute] int id, [FromBody] Watch watch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != watch.Id)
            {
                return BadRequest();
            }

            _context.Entry(watch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<WatchesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var watch = await _context.Watches.FindAsync(id);
            if (watch == null)
            {
                return NotFound();
            }

            _context.Watches.Remove(watch);
            await _context.SaveChangesAsync();

            return Ok(watch);
        }

        private bool WatchExists(int id)
        {
            return _context.Watches.Any(e => e.Id == id);
        }
    }
}
