using Domain.Entities;
using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Models;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize = 15;
        private IUnitOfWork _unitOfWork;
        private IEventInfoHelper _eventInfoHelper;

        public HomeController(IUnitOfWork unitOfWork, IEventInfoHelper eventInfoHelper)
        {
            _unitOfWork = unitOfWork;
            _eventInfoHelper = eventInfoHelper;
        }

        public ViewResult Index(int page = 1)
        {
            ShopInfoModel model = new ShopInfoModel
            {
                EventInfos = _unitOfWork.GetGenericRepository<EventInfo>()
                                        .GetAll().Where(a => a.EndDate>= System.DateTime.Now)
                                        .OrderByDescending(t => t.StartDate)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _unitOfWork.GetGenericRepository<EventInfo>().GetAll().Count()//0
                }
            };

            return View(model);
        }

        public ActionResult AboutEvent(int itemId)
        {
            var Item = _eventInfoHelper.GetEventById(itemId);            
            //var Item = _unitOfWork.GetGenericRepository<EventInfo>()
            //                       .GetAll()
            //                       .FirstOrDefault(x => x.EventInfoId == itemId);
            return View(Item);
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
 