using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;

namespace SumeraTravelCorporation.RepositoryPattern
{
    public interface ICountryRepository
    {
        public Task<List<T>> GetAllAsync<T>();

        public Task<T?> GetByIdAsync<T>(int id);

        public Task CreateAsync(Country country);

        public Task UpdateAsync(Country country);

        public Task DeleteAsync(int id);
        Task<bool> Exists(int departmentId);
    }
}
