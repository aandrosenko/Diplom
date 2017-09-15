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
        private IShopInfoHelper _shopInfoHelper;
        private IEventInfoHelper _eventInfoHelper;



        public AdminController(IUserHelper userHelper, IShopInfoHelper shopInfoHelper, IEventInfoHelper eventInfoHelper)
        {
            _userHelper = userHelper;
            _shopInfoHelper = shopInfoHelper;
            _eventInfoHelper = eventInfoHelper;
        }

        //public AdminController(IShopInfoHelper shopInfoHelper)
        //{
        //    _shopInfoHelper = shopInfoHelper;
        //}


        public ViewResult Users()
        {
            var users = _userHelper.GetUsers();

            return View(users);
        }

        public ViewResult ShopEditor()
        {           
            var shops = _shopInfoHelper.GetShopInfo();               

            return View(shops);
        }
                
        public ViewResult EventEditor()
        {
            var events = _eventInfoHelper.GetEventInfo();

            return View(events);
        }
        
        public ActionResult SelectedShopEditor(string name)
        {
            var item = _shopInfoHelper.GetShopByName(name);                   

            return View(item);
        }

    }
}