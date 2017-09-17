using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Attributes;
using WebUI.Helpers;
using WebUI.Models;
using Domain.Entities;

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


        //______________________//РАБОТА С ПОЛЬЗОВАТЕЛЯМИ
        public ViewResult Users()         
        {
            var users = _userHelper.GetUsers();
            return View(users);
        }


        //_____________________РАБОТА С МАГАЗИНАМИ
        public ViewResult ShopEditor()           
        {           
            var shops = _shopInfoHelper.GetShopInfo();
            return View(shops);
        }


        [HttpGet]
        public ActionResult CreateNewShop()  //Добавить НОВЫЙ магазин
        {
            return View(new ShopInfoModel());
        }
        [HttpPost]
        public ActionResult CreateNewShop(ShopInfoModel shop)
        {
            if (ModelState.IsValid)
            {
                _shopInfoHelper.CreateShopInfo(shop);
                return RedirectToAction("ShopEditor", "Admin");
            }
            return View(shop);
        }


        [HttpGet]
        public ActionResult SelectedShopEditor(int ShopInfoId) //РЕДАКТИРОВАТЬ выбранный магазин
        {
            var item = _shopInfoHelper.GetShopById(ShopInfoId);
            return View(item);
        }
        [HttpPost]
        public ActionResult SelectedShopEditor(ShopInfo shop)
        {      
            if (ModelState.IsValid)
            {
                _shopInfoHelper.UpdateShopInfo(shop);
                return RedirectToAction("ShopEditor", "Admin");
            }
            return View(shop);
        }


        public ActionResult DeleteShop(ShopInfoModel model) //УДАЛИТЬ выбранный магазин
        {
            _shopInfoHelper.DeleteShopInfo(model.ShopInfoId);
            return RedirectToAction("ShopEditor", "Admin");
        }

        
        //___________________________РАБОТА С СОБЫТИЯМИ
        public ViewResult EventEditor()         
        {
            var events = _eventInfoHelper.GetEventInfo();
            return View(events);
        }

    }
}