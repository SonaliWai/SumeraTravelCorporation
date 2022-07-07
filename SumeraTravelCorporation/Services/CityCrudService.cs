using AutoMapper;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.RepositoryPattern;
using System.Collections;

namespace SumeraTravelCorporation.Services
{
    public class CityCrudService : ICityCrudService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CityCrudService(
            ICityRepository cityRepository,
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<List<CityDto>> GetAllAsync()
        {

            //var employees = await _employeeRepository.GetAllAsyncOld();

            //var employeeViewModelsOld = employees
            //    .Select(e => _mapper.Map<EmployeeViewModel>(e))
            //    .ToList();

            var cityDtos = await _cityRepository.GetAllAsync<CityDto>();
            return cityDtos;
        }

        public async Task<CityDto?> GetByIdAsync(int id)
        {
            var city = await _cityRepository.GetByIdAsync<CityDto>(id);
            return city;

            //return _mapper.Map<EmployeeViewModel>(employee);
        }

        public async Task CreateAsync(CityDto city)
        {
            var cityDtos = _mapper.Map<CityDto>(city);
            await _cityRepository.CreateAsync(cityDtos);
        }

        public async Task UpdateAsync(CityDto city)
        {
            var cityDtos = _mapper.Map<CityDto>(city);
            await _cityRepository.UpdateAsync(cityDtos);
        }

        public async Task DeleteAsync(int id)
        {
            await _cityRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _cityRepository.Exists(id);
        }

        public async Task<IEnumerable> GetCountryListForDropDownAsync()
        {
            var countries = await _countryRepository.GetAllAsync<CountryDto>();

            return countries;
        }

        //public async Task DeleteSelectedCityAsync(int[] cityIds)
        //{
        //    foreach (var cityIdss in cityIds)
        //    {
        //        await _cityRepository.DeleteAsync(cityIdss);
        //    }
        //}

        //public async Task EmailRetiringEmployeesAsync()
        //{
        //    var cities = await _cityRepository.GetAllAsync<CityDto>();

        //    var retiringEmployees = cities.Where(e => DateTime.Now.AddYears(-60) > e.DateOfBirth).ToList();

        //    foreach (var retiringEmployee in retiringEmployees)
        //    {
        //        SendEmail(retiringEmployee);
        //    }
        //}

        //private void SendEmail(CityDto retiringEmployee)
        //{
        //    // Write code to email the employee
        //}

    }
}
