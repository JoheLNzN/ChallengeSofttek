namespace JncSofttek.Microservice.Repository.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
    }
}
