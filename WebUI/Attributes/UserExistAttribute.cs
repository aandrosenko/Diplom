using System.ComponentModel.DataAnnotations;
using WebUI.App_Start;
using WebUI.Helpers;

namespace WebUI.Attributes
{
    public class UserExistAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var user = NinjectWebCommon.Get<IUserHelper>().GetUserByEmail(value.ToString());
            return user == null;
        }
    }

}