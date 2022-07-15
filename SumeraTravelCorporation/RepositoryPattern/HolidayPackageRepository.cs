using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.RepositoryPattern
{
    public class HolidayPackageRepository : IHolidayPackageRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HolidayPackageRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<HolidayPackage>> GetAllAsync()
        {
            var employeeQuery = _context
                .HolidayPackages
                .Include(nameof(HolidayPackage.FromLocationRef))
                .Include(nameof(HolidayPackage.ToLocationRef))
                .Include(nameof(HolidayPackage.HotelRef));
            return await employeeQuery.ToListAsync();
        }

        public async Task<List<HolidayPackageDto>> GetAllAsync<HolidayPackageDto>()
        {
            var holidayPackageQuery = _mapper
                .ProjectTo<HolidayPackageDto>(_context.HolidayPackages);
            return await holidayPackageQuery.ToListAsync();
        }

        public async Task<HolidayPackageDto?> GetByIdAsync<HolidayPackageDto>(int id)
        {
            //var employee = await _context.Employees.Include(nameof(Employee.DepartmentRef))
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var holidayPackageQuery = _mapper
                .ProjectTo<HolidayPackageDto>(_context.HolidayPackages
                    .Where(m => m.HolidayPackageId == id));


            return await holidayPackageQuery.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(HolidayPackage holidayPackage)
        {
            _context.Add(holidayPackage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HolidayPackage holidayPackage)
        {
            _context.Update(holidayPackage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var holidayPackage = await _context.HolidayPackages.FindAsync(id);
            if (holidayPackage != null)
            {
                _context.HolidayPackages.Remove(holidayPackage);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.HolidayPackages.AnyAsync(e => e.HolidayPackageId == id);
        }
    }
}
