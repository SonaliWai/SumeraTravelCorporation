using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.RepositoryPattern
{
    public interface IHolidayPackageRepository
    {
        public Task<List<HolidayPackageDto>> GetAllAsync<HolidayPackageDto>();

        public Task<HolidayPackageDto?> GetByIdAsync<HolidayPackageDto>(int id);

        public Task CreateAsync(HolidayPackage location);

        public Task UpdateAsync(HolidayPackage location);

        public Task DeleteAsync(int id);
        Task<bool> Exists(int locationId);
    }
}
