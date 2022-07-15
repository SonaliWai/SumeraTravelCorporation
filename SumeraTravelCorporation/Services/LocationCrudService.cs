using AutoMapper;

using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern;

namespace SumeraTravelCorporation.Services
{
    public class LocationCrudService : ILocationCrudService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationCrudService(
            ILocationRepository locationRepository,
            IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<List<LocationDto>> GetAllAsync()
        {
            var locations = await _locationRepository.GetAllAsync<LocationDto>();
            var locationDto = locations
                .Select(d => _mapper.Map<LocationDto>(d))
                .ToList();
            return locationDto;
        }

        public async Task<LocationDto?> GetByIdAsync(int id)
        {
            var location = await _locationRepository.GetByIdAsync<LocationDto>(id);

            var locationDto = _mapper.Map<LocationDto>(location);

            return locationDto;
        }

        public async Task CreateAsync(LocationDto location)
        {
            var locationDto = _mapper.Map<Location>(location);

            await _locationRepository.CreateAsync(locationDto);
        }

        public async Task UpdateAsync(LocationDto location)
        {
            var locationDto = _mapper.Map<Location>(location);
            await _locationRepository.UpdateAsync(locationDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _locationRepository.DeleteAsync(id);
        }
        public async Task<bool> Exists(int id)
        {
            return await _locationRepository.Exists(id);
        }

    }
}
