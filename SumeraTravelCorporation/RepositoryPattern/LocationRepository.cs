using AutoMapper;

using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.RepositoryPattern
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LocationRepository(
            ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LocationDto>> GetAllAsync<LocationDto>()
        {
            var locationQuery = _mapper
                .ProjectTo<LocationDto>(_context.Locations);

            return await locationQuery.ToListAsync();
        }

        public async Task<LocationDto?> GetByIdAsync<LocationDto>(int id)
        {
            var location = _mapper
                .ProjectTo<LocationDto>(_context.Locations
                .Where(x => x.LocationId == id));

            return await location.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Location location)
        {
            await _context.AddAsync(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Location location)
        {
            _context.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {

            //var department = _Context.Departments.FirstOrDefault(x => x.Id == id);
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
            }

            await _context.SaveChangesAsync();
        }
        public async Task<bool> Exists(int id)
        {
            return await _context.Locations.AnyAsync(e => e.LocationId == id);
        }
    }
}
