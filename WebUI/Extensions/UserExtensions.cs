using Domain.Entities;

namespace WebUI.Extensions
{
    public static class UserExtensions
    {
        public static string UserFullName(this User user)
        {
            return user.IsAdmin
                    ? $"{user.LastName} {user.FirstName} (Admin)"
                    : $"{user.LastName} {user.FirstName}";
        }
    }
}