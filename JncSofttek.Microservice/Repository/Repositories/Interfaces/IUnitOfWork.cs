namespace JncSofttek.Microservice.Repository.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }
        IArticleRepository articleRepository { get; }
        public IOrderRepository orderRepository { get; }

        Task SaveChangesAsync();
        void InitTransaction();
        Task SaveChangesAndCommitTransactionAsync();
    }
}
