using Microsoft.AspNetCore.Identity;
using Movars.Core.Models;
using Newtonsoft.Json;

namespace Movars.Core.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Seeder(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed(string envName)
        {
            _context.Database.EnsureCreated();

            // seed default roles
            string[] roles = Enum.GetNames(typeof(Roles));
            try
            {
                foreach (var role in roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
            catch (Exception)
            {
                // Log error
                throw;
            }


            //TODO: add check for env path
            var path = @"../Movars.Core/Data/UserSeeds.json";
            var usersData = File.ReadAllText(path);
            var users = JsonConvert.DeserializeObject<List<ApplicationUser>>(usersData);

            if (!_userManager.Users.Any())
            {
                int count = 0;
                var role = String.Empty;
                foreach (var user in users ?? new List<ApplicationUser>())
                {
                    user.UserName = user.Email;
                    user.EmailConfirmed = true;
                    await _userManager.CreateAsync(user, "P@55w0rd");

                    if (count < 5)
                    {
                        role = roles[1];
                    }
                    else
                    {
                        role = roles[2];
                    }
                    user.IsActive = true;
                    await _userManager.AddToRoleAsync(user, role);
                    count++;
                }
            }

            // seed default admin
            if (await _userManager.FindByEmailAsync("admin@movars.com") == null)
            {
                await SeedAdminAsync();
            }

        }

        public async Task SeedAdminAsync()
        {
            var defaultAdmin = new ApplicationUser
            {
                UserName = "admin@movars.com",
                Email = "admin@movars.com",
                FirstName = "Admin",
                IsActive = true,
                EmailConfirmed = true,
                PhoneNumber = "+234 8100000000",
                PhoneNumberConfirmed = true
            };

            try
            {
                if (await _userManager.FindByIdAsync(defaultAdmin.Id) == null && await _userManager.FindByEmailAsync(defaultAdmin.Email) == null)
                {
                    await _userManager.CreateAsync(defaultAdmin, "P@55word");
                    await _userManager.AddToRolesAsync(defaultAdmin, Enum.GetNames(typeof(Roles)));
                }
            }
            catch (Exception ex)
            {
                // log error
                throw;
            }

        }

    }


    public enum Roles
    {
        Admin,
        Owner,
        Mover
    }
}

