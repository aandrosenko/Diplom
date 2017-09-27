using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Abstract;
using Domain.Entities;
using Domain.Repositories;
using WebUI.Models;
using WebUI.Context;

namespace WebUI.Helpers
{
    public class ShopInfoHelper : IShopInfoHelper
    {
        private IUnitOfWork _unitOfWork;
        private ShopInfoRepository _shopinfoRepo;

        public ShopInfoHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _shopinfoRepo = _unitOfWork.GetRepository<ShopInfoRepository>();
        }

        public ShopInfo GetShopByName(string shop)
        {
            return _shopinfoRepo.GetAll().FirstOrDefault(u => u.Name.Equals(shop));
        }

        public ShopInfo GetShopById(int shopId)
        {
            return _shopinfoRepo.GetAll().FirstOrDefault(u => u.ShopInfoId.Equals(shopId));
        }

        public void CreateShopInfo(ShopInfoModel model)  //Создать магазин
        {
            
            var shopinfo = new ShopInfo()
            {
                Name = model.Name,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                UserId = UserContext.Current.CurrentUser.UserId,
                
            };
            _shopinfoRepo.Add(shopinfo);
            _shopinfoRepo.Save();
        }

        public void UpdateShopInfo(ShopInfo model)
        {
            ShopInfo shop = GetShopById(model.ShopInfoId);            

            shop.Name = model.Name;
            shop.ShortDescription = model.ShortDescription;
            shop.Description = model.Description;
            //var shopinfo = new ShopInfo()
            //{
            //    //ShopInfoId = model.ShopInfoId,
            //    Name = model.Name,
            //    ShortDescription = model.ShortDescription,
            //    Description = model.Description,
            //    UserId = UserContext.Current.CurrentUser.UserId,

            //};
            _shopinfoRepo.Update(shop);
            _shopinfoRepo.Save();
        }

        public IEnumerable<ShopInfo> GetShopInfo()  //Взять список магазинов
        {
            return _shopinfoRepo.GetAll().OrderBy(t => t.Name);
        }


        public void DeleteShopInfo(int modelID)  //Удалить магазин
        {
            //_shopinfoRepo.Remove(model.ShopInfoId);
            _shopinfoRepo.Remove(modelID);
            _shopinfoRepo.Save();
        }





    }
}