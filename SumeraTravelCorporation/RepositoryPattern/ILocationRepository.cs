
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.RepositoryPattern
{
    public interface ILocationRepository
    {
        public Task<List<LocationDto>> GetAllAsync<LocationDto>();

        public Task<LocationDto?> GetByIdAsync<LocationDto>(int id);

        public Task CreateAsync(Location location);

        public Task UpdateAsync(Location location);

        public Task DeleteAsync(int id);
        Task<bool> Exists(int locationId);
    }
}
