using JncSofttek.Microservice.Common.Enums;
using JncSofttek.Microservice.DataAccess;
using JncSofttek.Microservice.DataAccess.Models;

namespace JncSofttek.Microservice.Repository
{
    public static class SeedData
    {
        public async static Task AddDefaulDataAsync(JncSofttekContext context)
        {
            List<User> users = new() {
                new User {
                    Id = 1,
                    EmailAddress = "admin@fake.com",
                    Password = "admin",
                    Role = UserRoleType.ADMIN,
                    CreationTime = DateTime.Now
                },
                new User {
                    Id = 2,
                    EmailAddress = "customer@fake.com",
                    Password = "customer",
                    Role = UserRoleType.DEFAULT,
                    CreationTime = DateTime.Now
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}
