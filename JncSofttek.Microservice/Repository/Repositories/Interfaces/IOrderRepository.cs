using JncSofttek.Microservice.DataAccess.Models;
using System.Threading.Tasks;

namespace JncSofttek.Microservice.Repository.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task CreateAsync(Order input);
    }
}
