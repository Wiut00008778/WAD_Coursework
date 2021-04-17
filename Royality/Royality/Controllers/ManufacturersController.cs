using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Royality.DAL;
using Royality.DAL.Models;
using Royality.DAL.Repository;

namespace Royality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IRepository<Manufacturer> _manufacturerRepo;

        public ManufacturersController(IRepository<Manufacturer> manufacturerRepo)
        {
            _manufacturerRepo = manufacturerRepo;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<IActionResult> GetManufacturers()
        {
            var manufacturers = await _manufacturerRepo.GetAllAsync();
            return Ok(manufacturers);
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manufacturer = await _manufacturerRepo.GetByIdAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

        // PUT: api/Manufacturers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturer([FromRoute] int id, [FromBody] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacturer.Id)
            {
                return BadRequest();
            }

            await _manufacturerRepo.UpdateAsync(manufacturer);

         
            return NoContent();
        }

        // POST: api/Manufacturers
        [HttpPost]
        public async Task<IActionResult> PostManufacturer([FromBody] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _manufacturerRepo.CreateAsync(manufacturer);


            return CreatedAtAction("GetManufacturer", new { id = manufacturer.Id }, manufacturer);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _manufacturerRepo.DeleteAsync(id);
            return NoContent();
        }

        private bool ManufacturerExists(int id)
        {
            return _manufacturerRepo.Exists(id);         
        }
    }
}
