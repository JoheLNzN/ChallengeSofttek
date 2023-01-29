using JncSofttek.Microservice.DataAccess;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;

namespace JncSofttek.Microservice.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JncSofttekContext _context;

        public IUserRepository UserRepository { get; }

        public UnitOfWork(
            JncSofttekContext context,
            IUserRepository userRepository)
        {
            _context = context;

            UserRepository = userRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _context.Dispose();
        }
    }
}
