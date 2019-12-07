using Microsoft.AspNetCore.Identity;

namespace Web.Server
{
    public class AdminDbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                var admin = new IdentityRole {Name = "Admin"};
                roleManager.CreateAsync(admin).Wait();
            }
            if (roleManager.FindByNameAsync("Student").Result == null)
            {
                var admin = new IdentityRole { Name = "Student" };
                roleManager.CreateAsync(admin).Wait();
            }

            if (userManager.FindByEmailAsync("root").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "Root@gmail.com",
                    Email = "Root@gmail.com"
                };
                var adminPSW = "Root_12345";

                var result = userManager.CreateAsync(user, adminPSW).Result;

                if (result.Succeeded) userManager.AddToRoleAsync(user, "Admin").Wait();
            }
            if (userManager.FindByEmailAsync("studnet").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "Student@gmail.com",
                    Email = "Student@gmail.com"
                };
                var adminPSW = "Student_12345";

                var result = userManager.CreateAsync(user, adminPSW).Result;

                if (result.Succeeded) userManager.AddToRoleAsync(user, "Student").Wait();
            }
        }
    }
}