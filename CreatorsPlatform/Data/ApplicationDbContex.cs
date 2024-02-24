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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().Property(user=>user.ID);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
