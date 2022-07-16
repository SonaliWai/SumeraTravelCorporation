using SumeraTravelCorporation.Data.Dtos;

namespace SumeraTravelCorporation.Services
{
    public interface IHolidayBookingCrudService
    {
        public Task<List<HolidayBookingDto>> GetAllAsync();

        public Task<HolidayBookingDto?> GetByIdAsync(int id);
        public Task CreateAsync(HolidayBookingDto holidayBookingDto);
        public Task UpdateAsync(HolidayBookingDto holidayBookingDto);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
