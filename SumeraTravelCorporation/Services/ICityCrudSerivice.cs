using SumeraTravelCorporation.Data.Dtos;
using System.Collections;

namespace SumeraTravelCorporation.Services
{
    public interface ICityCrudService
    {
        public Task<List<CityDto>> GetAllAsync();

        public Task<CityDto?> GetByIdAsync(int id);
        public Task CreateAsync(CityDto cityDto);
        public Task UpdateAsync(CityDto cityDto);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
