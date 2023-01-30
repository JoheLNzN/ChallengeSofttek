using JncSofttek.Microservice.DataAccess.Models;
using JncSofttek.Microservice.DataAccess;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JncSofttek.Microservice.Repository.Repositories
{
    public class OrderRepository : GenericRepository, IOrderRepository
    {
        public OrderRepository(JncSofttekContext context) : base(context) { }

        public async Task<List<Order>> GetAllAsync() =>
            await _context.Orders.OrderByDescending(a => a.CreationTime).ToListAsync();

        public async Task CreateAsync(Order input) => await _context.Orders.AddAsync(input);
    }
}
