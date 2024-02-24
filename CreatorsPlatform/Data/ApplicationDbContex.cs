using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using CreatorsPlatform.Models;

namespace CreatorsPlatform.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(user=>user.ID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
