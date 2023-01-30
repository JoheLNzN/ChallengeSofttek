using JncSofttek.Microservice.DataAccess.Models;

namespace JncSofttek.Microservice.Repository.Repositories.Interfaces
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
        Task<Article> GetBySkuAsync(string Sku);
        Task<int> CountArticlesNoStockAsync();
        Task CreateAsync(Article input);
        Task UpdateAsync(Article input);
    }
}
