using System.Web;
using Domain.Entities;
using Ninject.Web.Common;
using WebUI.App_Start;
using WebUI.Helpers;

namespace WebUI.Context
{
    public class UserContext
    {
        private static readonly IContextManager<IUserContext> contextManager;
        static UserContext()
        {
            contextManager = new ContextManager<IUserContext>("UserContext", () => new FormsPrincipalUserContext());
        }

        public static IUserContext Current => contextManager.GetContext();

        public static void Refresh()
        {
            contextManager.ClearContext();
            contextManager.LoadContext();
        }
    }

    public class FormsPrincipalUserContext : IUserContext
    {
        private User currentUser; 
        private bool userInitialized = false;
        public string UserFullName { get; private set; }

        public User CurrentUser
        {
            get
            {
                var isAuth = HttpContext.Current.User.Identity.IsAuthenticated;
                if (userInitialized || !isAuth)
                {
                    return this.currentUser;
                }

                var token = HttpContext.Current.User.Identity.Name;
                this.currentUser = NinjectWebCommon.Get<UserHelper>().GetUserByEmail(token);
                userInitialized = true;
                if (currentUser != null)
                {
                    UserFullName = currentUser.IsAdmin
                        ? $"{currentUser.LastName} {currentUser.FirstName} (Admin)"
                        : $"{currentUser.LastName} {currentUser.FirstName}";
                }

                return this.currentUser;
            }
        }

    }
}
