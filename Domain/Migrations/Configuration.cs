using Domain.Entities;

namespace Domain.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Domain.EFDbContext";
        }

        protected override void Seed(EFDbContext context)
        {
                context.Users.AddOrUpdate(u => u.Email, new User()
                {
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    IsAdmin = true,
                    Password = "e10adc3949ba59abbe56e057f20f883e"
                }); //123456
            context.SaveChanges();
        }
    }
}
