using AutoMapper;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern;
using System.Collections;

namespace SumeraTravelCorporation.Services
{
    public class CityCrudService : ICityCrudService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;


        public CityCrudService(ICityRepository cityRepository, IMapper mapper)
        {

            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CityDto cityDto)
        {
            try
            {


                //var city = _mapper.Map<City>(cityDto);



                var city = new City
                {
                    CountryRefId = cityDto.CountryRefId,
                    Name = cityDto.Name,

                };
                await _cityRepository.CreateAsync(city);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

        }

    
        public async Task DeleteAsync(int id)
        {
            await _cityRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _cityRepository.Exists(id);
        }

        public async Task<List<CityDto>> GetAllAsync()
        {
            var city = await _cityRepository.GetAllAsync<CityDto>();

            var cityDtoModels = city.Select(c => _mapper.Map<CityDto>(c))
                .ToList();
            return cityDtoModels;
        }

        public async Task<CityDto?> GetByIdAsync(int id)
        {
            var city = await _cityRepository.GetByIdAsync<CityDto>(id);
            var cityDtoModel = _mapper.Map<CityDto>(city);
            return cityDtoModel;

        }

        public async Task UpdateAsync(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            await _cityRepository.UpdateAsync(city);

        }
    }
}
