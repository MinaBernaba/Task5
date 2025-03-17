using BooksProject.Data.Identity;
using Microsoft.AspNetCore.Identity;

namespace BooksProject.Data.DataSeeder
{
    public static class RolesSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<Role> roleManager)
        {
            List<Role> roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Editor" },
                new Role { Name = "Viewer" },
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name!))
                    await roleManager.CreateAsync(role);
            }
        }

    }
}
