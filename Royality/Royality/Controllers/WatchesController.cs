using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Royality.DAL;
using Royality.DAL.Models;
using Royality.DAL.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Royality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchesController : ControllerBase
    {
        private readonly IRepository<Watch> _watchRepo;

        public WatchesController(IRepository<Watch> watchRepo)
        {
            _watchRepo = watchRepo;
        }

        // GET: api/<WatchesController>
        [HttpGet]
        public async Task<IActionResult> GetWatches()
        {
            var watches = await _watchRepo.GetAllAsync();
            return Ok(watches);
        }

        // GET api/<WatchesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWatch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var watch = await _watchRepo.GetByIdAsync(id);

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

            await _watchRepo.CreateAsync(watch);

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

            await _watchRepo.UpdateAsync(watch);


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


            await _watchRepo.DeleteAsync(id);

            return NoContent();
        }

        private bool WatchExists(int id)
        {
            return _watchRepo.Exists(id);
        }
    }
}
