using System.Linq;
using Domain.Abstract;
using Domain.Entities;
using Domain.Repositories;
using WebUI.Models;

namespace WebUI.Helpers
{
    public class UserHelper : IUserHelper
    {
        private IUnitOfWork _unitOfWork;
        private UserRepository _userRepo;

        public UserHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepo = _unitOfWork.GetRepository<UserRepository>();
        }

        public User GetUserByEmail(string email)
        {
            return _userRepo.GetAll().FirstOrDefault(u => u.Email.Equals(email));
        }

        public void CreateUser(RegisterViewModel model)
        {
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = PasswordHelper.GetPasswordHash(model.Password)
            };
            _userRepo.Add(user);
            _userRepo.Save();
        }
    }
}