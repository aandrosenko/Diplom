using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ShopController : Controller
    {
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

            string pattern = "\n";

            return View(Item);
        }

    }
}