using Domain.Abstract;
using Domain.Entities;

namespace Domain.Repositories
{
    public class ShopInfoRepository : GenericRepository<ShopInfo>
    {
        public ShopInfoRepository(EFDbContext context) : base(context)
        {
        }
    }
}
