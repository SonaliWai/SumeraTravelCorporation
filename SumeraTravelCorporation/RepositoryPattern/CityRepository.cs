using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Dtos;

namespace SumeraTravelCorporation.RepositoryPattern
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CityRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<List<CityDto>> GetAllAsync()
        //{
        //    var cityQuery = _context
        //        .Cities
        //        .Include(nameof(CityDto.CountryRefId));

        //    return await cityQuery.ToListAsync();
        //}

        public async Task<List<T>> GetAllAsync<T>()
        {
            var cityQuery = _mapper
                .ProjectTo<T>(_context.Cities);

            return await cityQuery.ToListAsync();
        }

        public async Task<T?> GetByIdAsync<T>(int id)
        {
            //var employee = await _context.Employees.Include(nameof(Employee.DepartmentRef))
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var cityQuery = _mapper
                .ProjectTo<T>(_context.Cities
                    .Where(m => m.Id == id));


            return await cityQuery.FirstOrDefaultAsync(); ;
        }

        public async Task CreateAsync(CityDto city)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CityDto city)
        {
            _context.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Cities.AnyAsync(e => e.Id == id);
        }
    }
}
