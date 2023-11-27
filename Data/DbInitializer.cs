//using LUSCMaintenance.Models;
//using Microsoft.AspNetCore.Identity;

//namespace LUSCMaintenance.Data
//{
//    public class DbInitializer
//    {
//        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
//        {
//            string adminEmail = "obueh.destiny@lmu.edu.ng";
//            string adminPassword = "@tRedti@-09521!";

//            if (await roleManager.FindByNameAsync("Admin") == null)
//            {
//                await roleManager.CreateAsync(new IdentityRole("Admin"));
//            }

//            if (await userManager.FindByNameAsync(adminEmail) == null)
//            {
//                User admin = new User { WebMail = adminEmail};
//                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);

//                if (result.Succeeded)
//                {
//                    await userManager.AddToRoleAsync(admin, "Admin");
//                }
//            }
//        }
//    }
//}
