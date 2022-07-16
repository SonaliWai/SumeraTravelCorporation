using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;

namespace SumeraTravelCorporation.RepositoryPattern
{
    public class HolidayPackageRepository : Repository<HolidayPackage>, IHolidayPackageRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public HolidayPackageRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }
    }
}
