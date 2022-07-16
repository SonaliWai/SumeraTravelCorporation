using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.Services;

namespace SumeraTravelCorporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayPackageController : ControllerBase
    {
        private IHolidayPackageCrudService _holidayPackageService;
        private readonly ILogger<HolidayPackageController> _logger;


        public HolidayPackageController(IHolidayPackageCrudService holidayPackageService, ILogger<HolidayPackageController> logger)
        {
            _holidayPackageService = holidayPackageService;
            _logger = logger;

        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayPackageDto>>> GetFlights()
        {
            try
            {
                var holidayPackages = await _holidayPackageService.GetAllAsync();
                return holidayPackages;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in get all of Flights");
                return NotFound();
            }
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayPackageDto>> GetHolidayPackage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var holidayPackage = await _holidayPackageService.GetByIdAsync((int)id);
            if (holidayPackage == null)
            {

                return NotFound();
            }


            return holidayPackage;
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolidayPackage(int id, HolidayPackageDto holidayPackage)
        {
            if (id != id)
            {
                return BadRequest();
            }


            try
            {
                await _holidayPackageService.UpdateAsync(holidayPackage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _holidayPackageService.Exists(id))
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

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HolidayPackage>> PostFlight(HolidayPackageDto holidayPackage)
        {
            if (holidayPackage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HolidayPackage'  is null.");
            }

            await _holidayPackageService.CreateAsync(holidayPackage);

            //return CreatedAtAction("GetCity", new { id = flight.Id }, flight);
            return Ok();
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolidayPackage(int id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var city = await _holidayPackageService.GetByIdAsync((int)id);
            if (city == null)
            {
                return NotFound();
            }

            await _holidayPackageService.DeleteAsync((int)id);


            return NoContent();
        }

    }
}
