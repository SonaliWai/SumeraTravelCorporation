using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.Services;

namespace SumeraTravelCorporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly ICountryCrudService _countryCrudService;
        private readonly ILogger<CountriesController> _logger;


        public CountriesController(
            ICountryCrudService countryCrudService,
            ILogger<CountriesController> logger)
        {
            _countryCrudService = countryCrudService;
            _logger = logger;
            //_context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries()
        {
          
            try
            {
                var countries = await _countryCrudService.GetAllAsync();
                return Ok(countries);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll");
            }
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
          
          if(id == 0)
            {
                return NotFound();
            }
          var country = await _countryCrudService.GetByIdAsync((int)id);
            if(country == null)
            {
                return NotFound();
            }
            return Ok(country);
          
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, CountryDto country)
        {
        
            if (id == null)
            {
                return NotFound();
            }
            if(id != country.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _countryCrudService.UpdateAsync(country);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!await _countryCrudService.Exists(country.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }                
            }
            return Ok(country);
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryDto>> PostCountry(CountryDto country)
        {
            
            if (ModelState.IsValid)
            {
                await _countryCrudService.CreateAsync(country);
            }
            return Ok(country);

        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {          
            if(id == null)
            {
                return NotFound();
            }
            var country = await _countryCrudService.GetByIdAsync((int)id);
            if(country == null)
            {
                return NotFound();
            }
            await _countryCrudService.DeleteAsync(id);

            return NoContent();
        }

        //private bool CountryExists(int id)
        //{
        //    return (_context.Countries?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
