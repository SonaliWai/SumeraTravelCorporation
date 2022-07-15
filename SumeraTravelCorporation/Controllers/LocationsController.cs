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
    public class LocationsController : ControllerBase
    {
        private readonly ILocationCrudService _locationCrudService;
        private readonly ILogger<LocationsController> _logger;

        public LocationsController(
            ILocationCrudService locationCrudService,
            ILogger<LocationsController> logger)
        {
            _locationCrudService = locationCrudService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetAllAsync()
        {
            try
            {
                var locations = await _locationCrudService.GetAllAsync();
                return Ok(locations);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll");
            }
        }
        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> GetLocation(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var location = await _locationCrudService.GetByIdAsync((int)id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }


        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, LocationDto location)
        {

            if (id == null)
            {
                return NotFound();
            }
            if (id != location.LocationId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _locationCrudService.UpdateAsync(location);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _locationCrudService.Exists(location.LocationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(location);
        }


        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(LocationDto location)
        {

            //if (ModelState.IsValid)
            //{
                await _locationCrudService.CreateAsync(location);
            //}

            return Ok();

        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var location = await _locationCrudService.GetByIdAsync((int)id);
            if (location == null)
            {
                return NotFound();
            }
            await _locationCrudService.DeleteAsync(id);

            return NoContent();
        }
    }
}
