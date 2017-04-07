using Domain.Entities;

namespace Domain.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(EFDbContext context) : base(context)
        {
        }
    }
}
