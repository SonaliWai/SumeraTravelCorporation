using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.Services;

namespace SumeraTravelCorporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityCrudService _cityCrudService;
        readonly ILogger<CitiesController> _logger;
        //private readonly ApplicationDbContext _context;

        public CitiesController(
            ICityCrudService cityCrudService,
            ILogger<CitiesController> _logger)
        {
            _cityCrudService = cityCrudService;
            _logger = _logger;
            //_context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {
            //if (_context.Cities == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Cities
            //      .Include("CountryRef")
            //      .ToListAsync();

            try
            {
                var cities = await _cityCrudService.GetAllAsync();
                return Ok(cities);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll");
            }
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            //if (_context.Cities == null)
            //{
            //    return NotFound();
            //}
            //  var city = await _context.Cities
            //      .Include("CountryRef")
            //      .SingleOrDefaultAsync(x => x.Id == id);

            //  if (city == null)
            //  {
            //      return NotFound();
            //  }

            //  return city;
            if (id == null)
            {
                return NotFound();
            }
            var city = await _cityCrudService.GetByIdAsync((int)id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, CityDto city)
        {
            //    if (id != city.Id)
            //    {
            //        return BadRequest();
            //    }

            //    _context.Entry(city).State = EntityState.Modified;

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!CityExists(id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return NoContent();
            if (id == null)
            {
                return NotFound();
            }
            //var city = await _cityCrudService.GetByIdAsync((int)id);
            if(id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _cityCrudService.UpdateAsync(city);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _cityCrudService.ExistsAsync(city.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(city);


        }

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(CityDto city)
        {
            if (ModelState.IsValid)
            {
                await _cityCrudService.CreateAsync(city);
            }
            return Ok(city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var city = await _cityCrudService.GetByIdAsync((int)id);
            if (city == null)
            {
                return NotFound();
            }
            await _cityCrudService.DeleteAsync(id);

            return NoContent();
        }

        //private bool Exists(int id)
        //{
        //    //return (_context.Cities?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
