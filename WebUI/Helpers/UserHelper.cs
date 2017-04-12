using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Helpers
{
    public class UserHelper : IUserHelper
    {
        private IUnitOfWork _unitOfWork;

        public UserHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUserByEmail(string email)
        {
            return _unitOfWork.GetGenericRepository<User>().GetAll().FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}