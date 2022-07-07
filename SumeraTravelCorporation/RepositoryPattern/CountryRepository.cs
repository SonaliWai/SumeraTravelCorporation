using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;

namespace SumeraTravelCorporation.RepositoryPattern
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<T>> GetAllAsync<T>()
        {
            //return await _context.Departments.ToListAsync();
            var countryQuery = _mapper
                .ProjectTo<T>(_context.Countries);

            return await countryQuery.ToListAsync();
        }

        public async Task<T?> GetByIdAsync<T>(int id)
        {
            //var department = await _context.Departments
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var country = await _mapper
                .ProjectTo<T>(_context.Countries
                    .Where(m => m.Id == id))
                .FirstOrDefaultAsync();

            return country;
        }

        public async Task CreateAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Countries.AnyAsync(e => e.Id == id);
        }
    }
}
