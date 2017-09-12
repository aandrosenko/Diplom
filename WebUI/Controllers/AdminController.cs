using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Attributes;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    [AdminAuthorize]
    public class AdminController : Controller
    {
        private IUserHelper _userHelper;

        public AdminController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        public ViewResult Users()
        {
            var users = _userHelper.GetUsers();

            return View(users);
        }
    }
}