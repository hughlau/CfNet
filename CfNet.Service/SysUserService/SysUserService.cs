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
*   Time：2018/11/27 17:15:35
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.SysUserService
{
    public class SysUserService:BaseService<SysUser>,ISysUserService
    {
        #region Field

        #endregion

        #region Ctor

        public SysUserService(IRepository<SysUser> repository):base(repository)
        {
        }



        #endregion

        #region Method

        public void Update(SysUser user)
        {
            SysUser model=_repository.GetModelByMainKey(user.UserID);
            model.UserName = user.UserName;
            model.IsExist = user.IsExist;
            model.Mobile = user.Mobile;
            model.Email = user.Email;
            model.UpdateTime = DateTime.Now.ToShortDateString();
            _repository.Update(model);
        }

        #endregion
    }
}
