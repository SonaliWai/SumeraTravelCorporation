using SumeraTravelCorporation.Data.Dtos;

namespace SumeraTravelCorporation.Services
{
    public interface IHolidayPackageCrudService
    {
        public Task<List<HolidayPackageDto>> GetAllAsync();

        public Task<HolidayPackageDto?> GetByIdAsync(int id);
        public Task CreateAsync(HolidayPackageDto holidayPackageDto);
        public Task UpdateAsync(HolidayPackageDto holidayPackageDto);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
