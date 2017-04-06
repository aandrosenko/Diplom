using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize = 15;
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ViewResult Index(int page = 1)
        {
            ShopInfoModel model = new ShopInfoModel
            {
                EventInfos = _unitOfWork.GetGenericRepository<EventInfo>()
                                        .GetAll()
                                        .OrderByDescending(t => t.StartDate)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = 0
                }
            };

            return View(model);
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}