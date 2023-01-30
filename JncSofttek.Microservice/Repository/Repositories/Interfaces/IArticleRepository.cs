using JncSofttek.Microservice.DataAccess.Models;

namespace JncSofttek.Microservice.Repository.Repositories.Interfaces
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
        Task CreateAsync(Article input);
    }
}
