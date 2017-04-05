using Domain.Entities;

namespace Domain.Repositories
{
    public class EventInfoRepository : GenericRepository<EventInfo>
    {
        public EventInfoRepository(EFDbContext context) : base(context)
        {
        }
    }
}
