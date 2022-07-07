using SumeraTravelCorporation.Data.Dtos;

namespace SumeraTravelCorporation.RepositoryPattern
{
    public interface ICityRepository
    {
        public Task<List<T>> GetAllAsync<T>();

        public Task<T?> GetByIdAsync<T>(int id);

        public Task CreateAsync(CityDto city);

        public Task UpdateAsync(CityDto city);

        public Task DeleteAsync(int id);
       Task<bool> Exists(int id);
    }
}
