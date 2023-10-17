using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponseHub.ResourceAccess
{
    public class IdentityAppDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options) : base(options)
        {
        }

        public static async Task CreateAdminAccount(IServiceProvider _serviceProvider, IConfiguration _configuration)
        {
            UserManager<IdentityUser> _userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> _roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var Name = _configuration["Data:AdminUser:Name"];
            var Email = _configuration["Data:AdminUser:Email"];
            var Phone = _configuration["Data:AdminUser:Phone"];
            var Password = _configuration["Data:AdminUser:Password"];
            var Role = _configuration["Data:AdminUser:Role"];

            if (await _userManager.FindByNameAsync(Name) == null)
            {
                if (await _roleManager.FindByNameAsync(Role) == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole(Role));
                }

                IdentityUser user = new IdentityUser()
                {
                    UserName = Name,
                    Email = Email,
                    PhoneNumber = Phone
                };

                IdentityResult result = await _userManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Role);
                }
            }
        }
    }
}
