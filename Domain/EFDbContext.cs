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
    }
}
