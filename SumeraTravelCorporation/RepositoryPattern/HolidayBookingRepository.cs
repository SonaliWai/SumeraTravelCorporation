using AutoMapper;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;

namespace SumeraTravelCorporation.RepositoryPattern
{
    public class HolidayBookingRepository : Repository<HolidayBooking>, IHolidayBookingRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public HolidayBookingRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }
    }
}
