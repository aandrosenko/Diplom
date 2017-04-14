namespace Domain.Repositories
{
    public abstract class BaseRepository
    {
        public abstract void Init(EFDbContext context);
    }
}
