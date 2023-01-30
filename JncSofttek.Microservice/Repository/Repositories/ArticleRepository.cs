using JncSofttek.Microservice.DataAccess;
using JncSofttek.Microservice.DataAccess.Models;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JncSofttek.Microservice.Repository.Repositories
{
    public class ArticleRepository : GenericRepository, IArticleRepository
    {
        public ArticleRepository(JncSofttekContext context) : base(context) { }

        public async Task<Article> GetBySkuAsync(string Sku) =>
            await _context.Articles.FirstOrDefaultAsync(a => a.Sku == Sku);

        public async Task<List<Article>> GetAllAsync() =>
            await _context.Articles.OrderByDescending(a => a.CreationTime).ToListAsync();

        public async Task CreateAsync(Article input)
        {
            await _context.Articles.AddAsync(input);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Article input) =>
            _context.Entry(input).State = EntityState.Modified;
    }
}
