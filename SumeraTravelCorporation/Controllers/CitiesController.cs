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
        private ICityCrudService _cityService;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ICityCrudService cityService, ILogger<CitiesController> logger)
        {
            _cityService = cityService;

            _logger = logger;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCitys()
        {
            try
            {
                var cities = await _cityService.GetAllAsync();
                return cities;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in get all of City");
                return NotFound();
            }
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var city = await _cityService.GetByIdAsync((int)id);
            if (city == null)
            {

                return NotFound();
            }


            return city;



        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, CityDto city)
        {
            if (id != id)
            {
                return BadRequest();
            }


            try
            {
                await _cityService.UpdateAsync(city);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _cityService.Exists(id))
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

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(CityDto city)
        {
            if (city == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Citys'  is null.");
            }
            await _cityService.CreateAsync(city);


            return Ok("Inserted");
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var city = await _cityService.GetByIdAsync((int)id);
            if (city == null)
            {
                return NotFound();
            }

            await _cityService.DeleteAsync((int)id);


            return NoContent();
        }
    }
}
