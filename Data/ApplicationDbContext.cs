using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieMVC.Models.DataBase;

namespace MovieMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Collection> Collections { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
