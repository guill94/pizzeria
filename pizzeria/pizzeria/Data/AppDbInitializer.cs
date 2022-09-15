using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using pizzeria.Data.Static;
using pizzeria.Models;
using System.Threading.Tasks;

namespace pizzeria.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
            }
        }

        public static async Task SeedUsersAndRoles(IApplicationBuilder appBuilder)
        {
            using(var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin));


                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));


                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));

                //User Admin
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                var adminUser = await userManager.FindByEmailAsync("admin@pizza.fr");

                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        UserName = "admin",
                        Email = "admin@pizza.fr",
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "B!gb@ngth9");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);

                }

                //User User
                var appUser = await userManager.FindByEmailAsync("johndoe@pizza.fr");

                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        UserName = "JohnDoe",
                        Email = "johndoe@pizza.fr",
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "B!gb@ngth9");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);

                }

            }     
        }
    }
}
