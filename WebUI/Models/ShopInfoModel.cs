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
        public IEnumerable<EventInfo> EventInfos { get; set; }

        public IEnumerable<ShopInfo> ShopInfoes { get; set; }

        public PagingInfo PagingInfo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FirstNameErrorMessage")]
        [Display(Name = "Имя")]
        public string ShopName { get; set; }
    }
}