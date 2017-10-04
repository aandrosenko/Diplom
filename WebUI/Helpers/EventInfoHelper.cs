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
                
        public IEnumerable<EventInfo> GetEventInfo()
        {
            return _eventInfoRepo.GetAll().OrderByDescending(t => t.EndDate);
        }


        public void CreateNewEvent(EventInfoModel model)
        {
            var newEvent = new EventInfo()
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                LongDescription = model.LongDescription,
                ShopInfoId = model.ShopInfoId
            };
            _eventInfoRepo.Add(newEvent);
            _eventInfoRepo.Save();            
        }


        public void DeleteEventInfo(int modelID)  //Удалить магазин
        {
            //_shopinfoRepo.Remove(model.ShopInfoId);
            //_shopinfoRepo.Remove(modelID);
            //_shopinfoRepo.Save();
            _eventInfoRepo.Remove(modelID);
            _eventInfoRepo.Save();
        }


    }
}