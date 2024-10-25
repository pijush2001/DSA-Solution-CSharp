using Microsoft.AspNetCore.Identity;

namespace RoleBasedAuthorization.Models
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAndAssignUsers(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Ensure roles exist
            var roles = new[] { "Developer", "Manager", "Client" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Assign users to roles
            var user = await userManager.FindByEmailAsync("dev@example.com");
            if (user != null && !(await userManager.IsInRoleAsync(user, "Developer")))
            {
                await userManager.AddToRoleAsync(user, "Developer");
            }

            var manager = await userManager.FindByEmailAsync("manager@example.com");
            if (manager != null && !(await userManager.IsInRoleAsync(manager, "Manager")))
            {
                await userManager.AddToRoleAsync(manager, "Manager");
            }

            var client = await userManager.FindByEmailAsync("client@example.com");
            if (client != null && !(await userManager.IsInRoleAsync(client, "Client")))
            {
                await userManager.AddToRoleAsync(client, "Client");
            }
        }
    }
}
