using SumeraTravelCorporation.Data.Dtos;

namespace SumeraTravelCorporation.Services
{
    public interface ICountryCrudService 
    {
        public Task<List<CountryDto>> GetAllAsync();

        public Task<CountryDto?> GetByIdAsync(int id);
        public Task CreateAsync(CountryDto country);
        public Task UpdateAsync(CountryDto country);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
