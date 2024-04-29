

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieMVC.Data;
using MovieMVC.Models.DataBase;
using MovieMVC.Models.Settings;

namespace MovieMVC.Services
{
    public class SeedService
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedService(IOptions<AppSettings> appSettings, ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedDataAsync()
        {
            await UpdateDataBaseAsync();
            await SeedRolesAsync();
            await SeedUserAsync();
            await SeedCollection();
        }

        private async Task UpdateDataBaseAsync()
        {
            //run through all migrations to make sure
            //the data base is up to date
            await _context.Database.MigrateAsync();
        }

        private async Task SeedRolesAsync()
        {
            if (_context.Roles.Any()) return;

            var adminRole = _appSettings.MovieSettings.DefaultCredentials.Role;
            await _roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        private async Task SeedUserAsync()
        {
            if (_context.Users.Any()) return;

            var credentials = _appSettings.MovieSettings.DefaultCredentials;
            var newUser = new IdentityUser()
            {
                Email = credentials.Email,
                UserName = credentials.Email,
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(newUser);
            await _userManager.AddToRoleAsync(newUser, credentials.Role);
        }

        private async Task SeedCollection()
        {
            if(_context.Collections.Any()) return;
            var defaultCollection = _appSettings.MovieSettings.DefaultCollection;
           
            _context.Collections.Add(new Collection()
            {
                Name = defaultCollection.Name,
                Description = defaultCollection.Description
            });

            await _context.SaveChangesAsync();

        }
    }
}
