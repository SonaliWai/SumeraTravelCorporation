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
    public class HolidayBookingController : ControllerBase
    {
        private IHolidayBookingCrudService _holidayBookingService;
        private readonly ILogger<HolidayBookingController> _logger;


        public HolidayBookingController(IHolidayBookingCrudService holidayBookingService, ILogger<HolidayBookingController> logger)
        {
            _holidayBookingService = holidayBookingService;
            _logger = logger;

        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayBookingDto>>> GetFlights()
        {
            try
            {
                var holidayBookings = await _holidayBookingService.GetAllAsync();
                return holidayBookings;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in get all of Flights");
                return NotFound();
            }
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayBookingDto>> GetHolidayBooking(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var holidayBooking = await _holidayBookingService.GetByIdAsync((int)id);
            if (holidayBooking == null)
            {

                return NotFound();
            }


            return holidayBooking;
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolidayBooking(int id, HolidayBookingDto holidayBooking)
        {
            if (id != id)
            {
                return BadRequest();
            }


            try
            {
                await _holidayBookingService.UpdateAsync(holidayBooking);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _holidayBookingService.Exists(id))
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
        public async Task<ActionResult<HolidayBooking>> PostBooking(HolidayBookingDto holidayBooking)
        {
            if (holidayBooking == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HolidayBooking'  is null.");
            }

            await _holidayBookingService.CreateAsync(holidayBooking);

            //return CreatedAtAction("GetCity", new { id = flight.Id }, flight);
            return Ok("Inserted");
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolidayBooking(int id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var city = await _holidayBookingService.GetByIdAsync((int)id);
            if (city == null)
            {
                return NotFound();
            }

            await _holidayBookingService.DeleteAsync((int)id);


            return NoContent();
        }

    }
}
