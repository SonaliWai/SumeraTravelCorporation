namespace SumeraTravelCorporation.RepositoryPattern.RepositoryBase
{
    public interface IRepository<DtoDataModel>
    {
        Task<List<DtoViewModel>> GetAllAsync<DtoViewModel>();

        Task<DtoViewModel?> GetByIdAsync<DtoViewModel>(int id) where DtoViewModel : ViewModelBase;

        Task CreateAsync(DtoDataModel entity);

        Task UpdateAsync(DtoDataModel entity);

        Task DeleteAsync(int id);

        Task<bool> Exists(int id);
    }
}
