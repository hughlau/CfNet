using CfNet.Core.Domain.SysUser;
using CfNet.Data.Infrastructure;
using CfNet.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/30 13:40:48
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.SysUserService
{
    public class SysUserAuthService : BaseService<SysUserAuth>, ISysUserAuthService
    {
        #region Field
        #endregion

        #region Ctor

        public SysUserAuthService(IRepository<SysUserAuth> repository) : base(repository)
        {
        }

        #endregion

        #region Method
        #endregion

    }
}
