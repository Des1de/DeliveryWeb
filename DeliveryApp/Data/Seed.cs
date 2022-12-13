using DeliveryApp.Models;
using Microsoft.AspNetCore.Identity;
using RunGroopWebApp.Data;

namespace DeliveryApp.Data
{
    
        public class Seed
        {
            public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    //Roles
                    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    if (!await roleManager.RoleExistsAsync(UserRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    //Users
                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                    string adminUserEmail = "des1de377@gmail.com";

                    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                    if (adminUser == null)
                    {
                        var newAdminUser = new AppUser()
                        {
                            UserName = "Des1de",
                            Email = adminUserEmail,
                            EmailConfirmed = true
                        };
                        await userManager.CreateAsync(newAdminUser, "Coding@1109?");
                        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    }

                    string appUserEmail = "user@food.com";

                    var appUser = await userManager.FindByEmailAsync(appUserEmail);
                    if (appUser == null)
                    {
                        var newAppUser = new AppUser()
                        {
                            UserName = "app-user",
                            Email = appUserEmail,
                            EmailConfirmed = true,
                        };
                        await userManager.CreateAsync(newAppUser, "Coding@1109?");
                        await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                    }
                }
            }
        }
 }
