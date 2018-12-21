using CfNet.Core.Domain.SysUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/12/21 15:34:42
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.Infrastructure.Authentication
{
    public interface IAuthenticationService
    {

        #region =============方法============

        void SignIn(SysUser user, bool createPersistentCookie);

        void SignOut();

        SysUser GetAuthenticatedUser();

        #endregion
    }
}