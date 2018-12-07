using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CfNet.Admin.Models.SysUser;
using CfNet.Core.Domain.Dict;
using CfNet.Core.Domain.SysUser;

namespace CfNet.Admin.ModelFactories
{
    public class SysUserModelFactory : ISysUserModelFactory
    {
        public SysUserEditModel PrepareUser(SysUser user, SysUserAuth userAuth)
        {
            SysUserEditModel model = new SysUserEditModel()
            {
                UserID = user.UserID,
                UserName = user.UserName,
                Mobile = user.Mobile,
                Email=user.Email,
                IsExist=user.IsExist==0
            };
            if (null!= userAuth)
            {
                model.LoginName = userAuth.Openid;
                model.Password = userAuth.AccessToken;
            }
            return model;
        }
    }
}