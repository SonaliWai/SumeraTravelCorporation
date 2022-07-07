using SumeraTravelCorporation.Data.Dtos;
using System.Collections;

namespace SumeraTravelCorporation.Services
{
    public interface ICityCrudService
    {
        public Task<List<CityDto>> GetAllAsync();

        public Task<CityDto?> GetByIdAsync(int id);
        public Task CreateAsync(CityDto city);
        public Task UpdateAsync(CityDto city);
        public Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable> GetCountryListForDropDownAsync();
    }
}
