using Domain.Entities;

namespace WebUI.Context
{
    public interface IUserContext
    {
        string UserFullName { get; }
        User CurrentUser { get; }
    }
}