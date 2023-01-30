using AutoMapper;
using JncSofttek.Microservice.DataAccess;
using JncSofttek.Microservice.DataAccess.Models;
using JncSofttek.Microservice.Repository.Repositories.Dtos.User;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Mail;

namespace JncSofttek.Microservice.Repository.Repositories
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        public UserRepository(JncSofttekContext context) : base(context) { }

        public async Task<List<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();

        public async Task<User> GetByEmailAddress(string emailAddress) =>
            await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == emailAddress);

        public async Task<User> GetByEmailAddressAndPasswordAsync(string emailAddress, string password) =>
            await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == emailAddress &&
                                                          u.Password == password);
    }
}
