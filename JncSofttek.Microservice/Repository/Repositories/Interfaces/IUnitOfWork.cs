namespace JncSofttek.Microservice.Repository.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }
        IArticleRepository articleRepository { get; }
    }
}
