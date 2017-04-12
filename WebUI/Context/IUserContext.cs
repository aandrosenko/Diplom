using Domain.Entities;

namespace WebUI.Context
{
    public interface IUserContext
    {
        User CurrentUser { get; }
    }
}