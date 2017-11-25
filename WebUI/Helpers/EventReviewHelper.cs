using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Models;
using Domain.Abstract;
using Domain.Entities;
using Domain.Repositories;
using WebUI.Context;

namespace WebUI.Helpers
{
    public class EventReviewHelper : IEventReviewHelper
    {
        private IUnitOfWork _unitOfWork;        
        private EventReviewRepository _eventReviewRepo;

        public EventReviewHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _eventReviewRepo = _unitOfWork.GetRepository<EventReviewRepository>();
        }

        public void CreateNewEventReview(EventReviewModel model)
        {
            var newReview = new EventReview()
            {
                UserId = UserContext.Current.CurrentUser.UserId,
                EventInfoId = model.EventInfoId,
                Text = model.Text,
                CreateDate = model.CreateDate,                
            };
            _eventReviewRepo.Add(newReview);
            _eventReviewRepo.Save();
        }



    }
}