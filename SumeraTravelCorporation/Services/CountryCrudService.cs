using AutoMapper;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern;

namespace SumeraTravelCorporation.Services
{
    public class CountryCrudService : ICountryCrudService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryCrudService(
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<List<CountryDto>> GetAllAsync()
        {
            var countries = await _countryRepository.GetAllAsync<CountryDto>();

            var countryDtos = countries
                .Select(d => _mapper.Map<CountryDto>(d))
                .ToList();

            return countryDtos;
        }

        public async Task<CountryDto?> GetByIdAsync(int id)
        {
            var countries = await _countryRepository.GetByIdAsync<CountryDto>(id);

            var countryDtos = _mapper.Map<CountryDto>(countries);

            return countryDtos;
        }

        public async Task CreateAsync(CountryDto country)
        {
            var countryDtos = _mapper.Map<Country>(country);
            await _countryRepository.CreateAsync(countryDtos);
        }

        public async Task UpdateAsync(CountryDto country)
        {
            var countryDtos = _mapper.Map<Country>(country);
            await _countryRepository.UpdateAsync(countryDtos);
        }

        public async Task DeleteAsync(int id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _countryRepository.Exists(id);
        }

    }
}
