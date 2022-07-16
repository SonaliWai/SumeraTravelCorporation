using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;

namespace SumeraTravelCorporation.RepositoryPattern.RepositoryBase
{
    public class ViewDtoBase
    {
        public int? Id { get; set; }
    }

    public class DataModelBase
    {
        public int Id { get; set; }
    }
    public class Repository<TDataModel> : IRepository<TDataModel> where TDataModel : DataModelBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        protected readonly DbSet<TDataModel> DbSet;

        public Repository(ApplicationDbContext db, IMapper mapper)
        {
            DbSet = db.Set<TDataModel>();
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<TDtoModel>> GetAllAsync<TDtoModel>()
        {
            var query = _mapper
                .ProjectTo<TDtoModel>(DbSet);

            return await query.ToListAsync();
        }

        public async Task<TDtoModel?> GetByIdAsync<TDtoModel>(int id) where TDtoModel : ViewDtoBase
        {
            var query = _mapper
                       .ProjectTo<TDtoModel>(DbSet)
                       .Where(m => m.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(TDataModel entity)
        {
            try
            {
                await DbSet.AddAsync(entity);

                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
                { 

            }
           
        }

        public async Task UpdateAsync(TDataModel entity)
        {
            DbSet.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await DbSet.FindAsync(id);
            if (employee != null)
            {
                DbSet.Remove(employee);
            }

            await _db.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await DbSet.AnyAsync(e => e.Id == id);
        }
    }
}
