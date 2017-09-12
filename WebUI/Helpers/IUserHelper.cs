using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Helpers
{
    public interface IUserHelper
    {
        User GetUserByEmail(string email);
        void CreateUser(RegisterViewModel model);
        IEnumerable<User> GetUsers();
    }
}
