using JncSofttek.Microservice.DataAccess;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace JncSofttek.Microservice.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JncSofttekContext context;
        private IDbContextTransaction _transaction;

        public IUserRepository userRepository { get; }
        public IArticleRepository articleRepository { get; }
        public IOrderRepository orderRepository { get; }

        public UnitOfWork(
            JncSofttekContext context,
            IUserRepository userRepository,
            IArticleRepository articleRepository,
            IOrderRepository orderRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.articleRepository = articleRepository;
            this.orderRepository = orderRepository;
        }

        public void InitTransaction() => _transaction = context.Database.BeginTransaction();

        public async Task SaveChangesAndCommitTransactionAsync()
        {
            await context.SaveChangesAsync();
            _transaction.Commit();
            _transaction = null;
        }

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) context.Dispose();
        }
    }
}
