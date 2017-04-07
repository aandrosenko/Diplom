using Domain.Entities;

namespace WebUI.Helpers
{
    public interface IUserHelper
    {
        User GetUserByEmail(string email);
    }
}
