using CfNet.Core.Domain.SysUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/12/21 15:56:17
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.Infrastructure.Authentication
{
    public interface IUserRegistrationService
    {

        #region =============方法============

        UserLoginResults ValidateUser(string openid, string token);

        #endregion
    }
}