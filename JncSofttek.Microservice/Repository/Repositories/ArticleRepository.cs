using JncSofttek.Microservice.DataAccess;
using JncSofttek.Microservice.DataAccess.Models;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JncSofttek.Microservice.Repository.Repositories
{
    public class ArticleRepository : GenericRepository, IArticleRepository
    {
        public ArticleRepository(JncSofttekContext context) : base(context) { }

        public async Task<List<Article>> GetAllAsync() =>
            await _context.Articles.OrderByDescending(a => a.CreationTime).ToListAsync();

        public async Task CreateAsync(Article input)
        {
            await _context.Articles.AddAsync(input);
            await _context.SaveChangesAsync();
        }
    }
}
