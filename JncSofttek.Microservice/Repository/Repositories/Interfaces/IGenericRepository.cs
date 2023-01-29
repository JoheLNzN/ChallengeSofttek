namespace JncSofttek.Microservice.Repository.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
    }
}
