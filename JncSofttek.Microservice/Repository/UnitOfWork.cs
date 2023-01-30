using JncSofttek.Microservice.DataAccess;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;

namespace JncSofttek.Microservice.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JncSofttekContext context;

        public IUserRepository userRepository { get; }
        public IArticleRepository articleRepository { get; }

        public UnitOfWork(
            JncSofttekContext context,
            IUserRepository userRepository,
            IArticleRepository articleRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.articleRepository = articleRepository;
        }

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
