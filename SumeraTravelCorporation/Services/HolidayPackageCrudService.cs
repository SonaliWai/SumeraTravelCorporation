using AutoMapper;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern;

namespace SumeraTravelCorporation.Services
{
    public class HolidayPackageCrudService : IHolidayPackageCrudService
    {
        private readonly IHolidayPackageRepository _holidayPackageRepository;
        private readonly IMapper _mapper;

        public HolidayPackageCrudService(IHolidayPackageRepository flightRepository, IMapper mapper)
        {
            _holidayPackageRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(HolidayPackageDto flightDto)
        {
            var flight = _mapper.Map<HolidayPackage>(flightDto);
            await _holidayPackageRepository.CreateAsync(flight);
        }

        public async Task DeleteAsync(int id)
        {
            await _holidayPackageRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _holidayPackageRepository.Exists(id);
        }

        public async Task<List<HolidayPackageDto>> GetAllAsync()
        {
            var holidayPackage = await _holidayPackageRepository.GetAllAsync<HolidayPackageDto>();

            var holidatPackageDtoModels = holidayPackage.Select(c => _mapper.Map<HolidayPackageDto>(c))
                .ToList();
            return holidatPackageDtoModels;
        }

        public async Task<HolidayPackageDto?> GetByIdAsync(int id)
        {
            var holidayPackage = await _holidayPackageRepository.GetByIdAsync<HolidayPackageDto>(id);
            var holidatPackageDtoModels = _mapper.Map<HolidayPackageDto>(holidayPackage);
            return holidatPackageDtoModels;
        }

        public async Task UpdateAsync(HolidayPackageDto holidayPackageDto)
        {
            var holidayPackage = _mapper.Map<HolidayPackage>(holidayPackageDto);
            await _holidayPackageRepository.UpdateAsync(holidayPackage);
        }
    }
}
