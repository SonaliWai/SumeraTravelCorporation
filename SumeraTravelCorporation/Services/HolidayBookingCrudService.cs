using AutoMapper;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern;

namespace SumeraTravelCorporation.Services
{
    public class HolidayBookingCrudService : IHolidayBookingCrudService
    {
        private readonly IHolidayBookingRepository _holidayBookingRepository;
        private readonly IMapper _mapper;

        public HolidayBookingCrudService(IHolidayBookingRepository holidayBookingRepository, IMapper mapper)
        {
            _holidayBookingRepository = holidayBookingRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(HolidayBookingDto holidayBookingDto)
        {
            var holidayBooking = _mapper.Map<HolidayBooking>(holidayBookingDto);
            await _holidayBookingRepository.CreateAsync(holidayBooking);
        }

        public async Task DeleteAsync(int id)
        {
            await _holidayBookingRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _holidayBookingRepository.Exists(id);
        }

        public async Task<List<HolidayBookingDto>> GetAllAsync()
        {
            var holidayBooking = await _holidayBookingRepository.GetAllAsync<HolidayBookingDto>();

            var holidatBookingDtoModels = holidayBooking.Select(c => _mapper.Map<HolidayBookingDto>(c))
                .ToList();
            return holidatBookingDtoModels;
        }

        public async Task<HolidayBookingDto?> GetByIdAsync(int id)
        {
            var holidayBooking = await _holidayBookingRepository.GetByIdAsync<HolidayBookingDto>(id);
            var holidatBookingDtoModels = _mapper.Map<HolidayBookingDto>(holidayBooking);
            return holidatBookingDtoModels;
        }

        public async Task UpdateAsync(HolidayBookingDto holidayBookingDto)
        {
            var holidayBooking = _mapper.Map<HolidayBooking>(holidayBookingDto);
            await _holidayBookingRepository.UpdateAsync(holidayBooking);
        }
    }
}
