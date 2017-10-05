using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Helpers
{
    public interface IEventInfoHelper
    {
        EventInfo GetEventInfoByData(DateTime data);
        void CreateNewEvent(EventInfoModel model);
        void DeleteEventInfo(int modelID);
        EventInfo GetEventById(int eventId);
        void UpdateEventInfo(EventInfo model);
        IEnumerable<EventInfo> GetEventInfo();
    }
}
