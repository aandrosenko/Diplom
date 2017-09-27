using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebUI.Attributes;
using WebUI.Properties;
using Domain.Entities;

namespace WebUI.Models
{
    public class ShopInfoModel
    {
              
        public int ShopInfoId { get; set; }        
        public string Name { get; set; }        
        public string Logo { get; set; }
        public string ShortDescription { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<EventInfo> EventInfos { get; set; }
        public IEnumerable<ShopInfo> ShopInfoes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}