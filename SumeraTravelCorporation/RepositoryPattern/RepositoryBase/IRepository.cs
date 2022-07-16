namespace SumeraTravelCorporation.RepositoryPattern.RepositoryBase
{
    public interface IRepository<TDataModel>
    {
        Task<List<TDtoModel>> GetAllAsync<TDtoModel>();

        Task<TDtoModel?> GetByIdAsync<TDtoModel>(int id) where TDtoModel : ViewDtoBase;

        Task CreateAsync(TDataModel entity);

        Task UpdateAsync(TDataModel entity);

        Task DeleteAsync(int id);

        Task<bool> Exists(int id);
    }
}
