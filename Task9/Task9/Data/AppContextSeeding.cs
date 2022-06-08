using Task9.Models;

namespace Task9.Data
{
    public class AppContextSeeding
    {
        public static async System.Threading.Tasks.Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TaskContext>();

                context.Database.EnsureCreated();

                // Roles
                if (!context.Roles.Any())
                {
                    await context.Roles.AddRangeAsync(
                        new Role()
                        {
                            Name = "TeamLead"
                        },
                        new Role()
                        {
                            Name = "Senior"
                        },
                        new Role()
                        {
                            Name = "Middle"
                        },
                        new Role()
                        {
                            Name = "Junior"
                        });
                    await context.SaveChangesAsync();
                }

                // Users
                if (!context.Users.Any())
                {
                    await context.Users.AddRangeAsync(
                        new User()
                        {
                            FullName = "John Doe",
                            RoleId = 1,
                            Email = "JDoe.gmail.com",
                            Password = "AD12345"
                        }, new User()
                        {
                            FullName = "Alex Brown",
                            RoleId = 2,
                            Email = "ABrown.gmail.com",
                            Password = "AB12345"
                        }, new User()
                        {
                            FullName = "Leanne Graham",
                            RoleId = 2,
                            Email = "Leanne.gmail.com",
                            Password = "LG12345"
                        }, new User()
                        {
                            FullName = "Ervin Howell",
                            RoleId = 3,
                            Email = "EHowell.gmail.com",
                            Password = "EH12345"
                        }, new User()
                        {
                            FullName = "Clementine Bauch",
                            RoleId = 3,
                            Email = "CBauch.gmail.com",
                            Password = "CB12345"
                        }, new User()
                        {
                            FullName = "Patricia Lebsack",
                            RoleId = 4,
                            Email = "PatricaL.gmail.com",
                            Password = "PL12345"
                        }, new User()
                        {
                            FullName = "Chelsey Dietrich",
                            RoleId = 4,
                            Email = "ChelseyD.gmail.com",
                            Password = "CD12345"
                        });
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
