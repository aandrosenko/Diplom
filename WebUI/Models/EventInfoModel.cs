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
    public class EventInfoModel
    {
        public int EventInfoId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string LogoUrl { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int ShopInfoId { get; set; }
        public string Name { get; set; }
        public IEnumerable<EventInfo> EventInfos { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}