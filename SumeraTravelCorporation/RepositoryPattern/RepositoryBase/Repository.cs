using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;

namespace SumeraTravelCorporation.RepositoryPattern.RepositoryBase
{
    public class ViewModelBase
    {
        public int Id { get; set; }
    }

    public class DataModelBase
    {
        public int Id { get; set; }
    }
    public class Repository<DtoDataModel> : IRepository<DtoDataModel> where DtoDataModel : DataModelBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        protected readonly DbSet<DtoDataModel> DbSet;

        public Repository(ApplicationDbContext db, IMapper mapper)
        {
            DbSet = db.Set<DtoDataModel>();
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<DtoViewModel>> GetAllAsync<DtoViewModel>()
        {
            var countryQuery = _mapper
                .ProjectTo<DtoViewModel>(DbSet);

            return await countryQuery.ToListAsync();
        }

        public async Task<DtoViewModel?> GetByIdAsync<DtoViewModel>(int id) where DtoViewModel : ViewModelBase
        {
            var countryQuery = _mapper
                .ProjectTo<DtoViewModel>(DbSet)
                    .Where(c => c.Id == id);

            return await countryQuery.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(DtoDataModel entity)
        {
            await DbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(DtoDataModel entity)
        {
            DbSet.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var country = await DbSet.FindAsync(id);
            if (country != null)
            {
                DbSet.Remove(country);
            }

            await _db.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await DbSet.AnyAsync(e => e.Id == id);
        }
    }
}
