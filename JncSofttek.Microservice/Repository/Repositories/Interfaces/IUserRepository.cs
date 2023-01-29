using JncSofttek.Microservice.DataAccess.Models;

namespace JncSofttek.Microservice.Repository.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAddressAndPasswordAsync(string emailAddress, string password);
    }
}
