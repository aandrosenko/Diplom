using Domain.Entities;
using WebUI.Models;

namespace WebUI.Helpers
{
    public interface IUserHelper
    {
        User GetUserByEmail(string email);
        void CreateUser(RegisterViewModel model);
    }
}
