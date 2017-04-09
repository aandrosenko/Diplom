using Domain.Entities;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class ShopInfoModel
    {
        public IEnumerable<EventInfo> EventInfos { get; set; }

        public IEnumerable<ShopInfo> ShopInfoes { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}