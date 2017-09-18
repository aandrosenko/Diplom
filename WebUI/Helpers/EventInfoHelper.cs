using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;
using Domain.Repositories;
using WebUI.Models;

namespace WebUI.Helpers
{
    public class EventInfoHelper : IEventInfoHelper
    {
        private IUnitOfWork _unitOfWork;
        private EventInfoRepository _eventInfoRepo;


        public EventInfoHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _eventInfoRepo = _unitOfWork.GetRepository<EventInfoRepository>();
        }

        public EventInfo GetEventInfoByData(DateTime data)
        {
            return _eventInfoRepo.GetAll().FirstOrDefault(u => u.EndDate.Equals(data));
        }

        public void CreateEventInfo(EventInfoModel model)
        {
            //var user = new User()
            //{
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    Email = model.Email,
            //    Password = PasswordHelper.GetPasswordHash(model.Password)
            //};
            //_eventInfoRepo.Add(user);
            //_eventInfoRepo.Save();
        }

        public IEnumerable<EventInfo> GetEventInfo()
        {
            return _eventInfoRepo.GetAll().OrderByDescending(t => t.EndDate);
        }



    }
}