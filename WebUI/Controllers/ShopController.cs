using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ShopController : Controller
    {
        /* private IShopInfoRepository catalogmagazinovRepozitory;
         // GET: CatalogMagazinov


         public CatalogMagazinovController(IShopInfoRepository catalogRepo)
         {

             catalogmagazinovRepozitory = catalogRepo;
         }


         public ActionResult Catalog()
         {
             return View(catalogmagazinovRepozitory.CatalogMagazinov);
         }*/


        private IUnitOfWork _unitOfWork;

        public ShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ViewResult Shops(int page = 1)
        {            
            ShopInfoModel model = new ShopInfoModel
            {
                ShopInfoes = _unitOfWork.GetGenericRepository<ShopInfo>()
                                        .GetAll()
                                        .OrderByDescending(t => t.Name)                                             
            };
            return View(model);
        }


        public ActionResult ShopDescription(int itemId)
        {
            var Item = _unitOfWork.GetGenericRepository<ShopInfo>()
                                    .GetAll()
                                    .FirstOrDefault(x => x.ShopInfoId == itemId);            
            return View(Item);
        }

    }
}