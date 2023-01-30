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


            var articles = new List<Article>()
            {
                new Article{
                    Id = 1,
                    Name = "POLO VERDE - VERANO 2023",
                    Sku = "6c5a8b94-f77d-4a64-ac23-c4113777b838",
                    Price = 58.99M,
                    Stock = 10
                },

                new Article{
                    Id = 2,
                    Name = "POLO ROJO - VERANO 2023",
                    Sku = "2da777c0-962c-4f9a-944c-1350e3586ca8",
                    Price = 78.00M,
                    Stock = 10
                },

                 new Article{
                    Id = 3,
                    Name = "POLO AZUL - VERANO 2023",
                    Sku = "40c9b8b7-647d-4a7b-bf1b-e1f3128709c0",
                    Price = 74.20M,
                    Stock = 10
                },
                  new Article{
                    Id = 4,
                    Name = "POLO MORADO - VERANO 2023",
                    Sku = "9afc9d40-6a4a-4648-a930-040ade09c688",
                    Price = 55M,
                    Stock = 10,
                    CreationTime = new DateTime(2022, 10, 15)
                },
                  new Article{
                    Id = 5,
                    Name = "POLO AMARILLO - VERANO 2023",
                    Sku = "18dd2068-d98b-477b-af8c-73a8b46d573e",
                    Price = 32.32M,
                    Stock = 10,
                    CreationTime = new DateTime(2022, 11, 2)
                },
                   new Article{
                    Id = 6,
                    Name = "POLO NEGRO - VERANO 2023",
                    Sku = "5d052be9-5abc-4d0d-ae7e-5cbe2ca483b5",
                    Price = 100.00M,
                    Stock = 10,
                    CreationTime = new DateTime(2022, 10, 05)
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.Articles.AddRangeAsync(articles);
            await context.SaveChangesAsync();
        }
    }
}
