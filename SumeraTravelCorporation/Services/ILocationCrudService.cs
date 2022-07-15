using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Services
{
    public interface ILocationCrudService
    {
        public Task<List<LocationDto>> GetAllAsync();
        public Task<LocationDto?> GetByIdAsync(int id);
        public Task CreateAsync(LocationDto location);
        public Task UpdateAsync(LocationDto location);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
