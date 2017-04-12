using System.Web.Mvc;
using System.Web.Security;
using WebUI.Context;
using WebUI.Helpers;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IUserHelper _userHelper;

        public AccountController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        public ViewResult Login(string returnUrl = null)
        {
            var model = new LoginViewModel {ReturnUrl = returnUrl};

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                UserContext.Refresh();
                var x = UserContext.Current.CurrentUser;

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    Response.Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Login");
        }
    }
}