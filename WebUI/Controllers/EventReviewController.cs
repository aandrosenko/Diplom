using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Context;
using WebUI.Helpers;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class EventReviewController : Controller
    {
        private IUserHelper _userHelper;
        private IEventReviewHelper _eventReviewHelper;
        

        public EventReviewController(IUserHelper userHelper, IEventReviewHelper eventReviewHelper)
        {
            _userHelper = userHelper;
            _eventReviewHelper = eventReviewHelper;
        }

        public ActionResult AllEventReview()
        {
            return View();
        }


        [HttpGet]
        [ChildActionOnly]
        public ActionResult AddNewEventReview(EventInfo eventInf)
        {
            EventReviewModel newReview = new EventReviewModel();
            newReview.EventInfoId = eventInf.EventInfoId;
            return PartialView(newReview);
        }
        [HttpPost]
        public ActionResult AddNewEventReview(EventReviewModel newReview)
        {
            if (ModelState.IsValid)                           
            {
                DateTime localDate = DateTime.Now;
                newReview.UserId = UserContext.Current.CurrentUser.UserId;
                newReview.CreateDate = localDate;
                _eventReviewHelper.CreateNewEventReview(newReview);
                //ModelState.Clear();
                return PartialView();
            }           
            return PartialView();
        }

    }
}