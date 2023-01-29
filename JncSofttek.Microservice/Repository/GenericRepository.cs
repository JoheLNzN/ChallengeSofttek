using AutoMapper;
using JncSofttek.Microservice.DataAccess;

namespace JncSofttek.Microservice.Repository
{
    public class GenericRepository
    {
        public readonly JncSofttekContext _context;
        public GenericRepository(JncSofttekContext context) => _context = context;
    }
}
