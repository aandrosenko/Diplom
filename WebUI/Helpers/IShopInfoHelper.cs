using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Helpers
{
    public interface IShopInfoHelper
    {
        ShopInfo GetShopByName(string shop);
        ShopInfo GetShopById(int shopId);
        void CreateShopInfo(ShopInfoModel model);
        IEnumerable<ShopInfo> GetShopInfo();
        void DeleteShopInfo(int modelID);
        void UpdateShopInfo(ShopInfo model);
    }
}
