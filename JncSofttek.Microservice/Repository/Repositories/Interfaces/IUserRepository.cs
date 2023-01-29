using JncSofttek.Microservice.DataAccess.Models;
using JncSofttek.Microservice.Repository.Repositories.Dtos.User;

namespace JncSofttek.Microservice.Repository.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAddressAndPasswordAsync(string emailAddress, string password);
    }
}
