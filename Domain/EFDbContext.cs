using Domain.Entities;
using System.Data.Entity;

namespace Domain
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(): base("EFDbContext")
        { }

        public DbSet<EventInfo> EventInfos { get; set; }
        public DbSet<ShopInfo> ShopInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EventReview> EventReviews { get; set; }
        public DbSet<ShopReview> ShopReviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopInfo>()
                        .HasRequired(c => c.Owner)
                        .WithMany(u => u.Shops)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShopReview>()
                .HasRequired(s => s.User)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
