using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CfNet.Core.Domain.SysUser;
using CfNet.Service.SysUserService;
using DapperExtensions;

/****************************************************************
*   Author：L
*   Time：2018/12/21 15:57:11
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Service.Infrastructure.Authentication
{
    public partial class UserRegistrationService : IUserRegistrationService
    {

        #region =============属性============

        private readonly ISysUserAuthService _sysUserAuthService;

        #endregion

        #region ===========构造函数==========

        public UserRegistrationService(ISysUserAuthService sysUserAuthService)
        {
            this._sysUserAuthService = sysUserAuthService;
        }

        #endregion

        #region ===========基本方法==========



        #endregion

        #region =============方法============

        public UserLoginResults ValidateUser(string openid, string token)
        {
            IPredicate predicate = Predicates.Field<SysUserAuth>(p => p.Openid, Operator.Eq, openid);
            IPredicateGroup group = Predicates.Group(GroupOperator.And, predicate);
            SysUserAuth userAuth = _sysUserAuthService.GetFirstOrDefault(group);
            if (userAuth == null)
            {
                return UserLoginResults.UserNotExist;
            }

            IPredicate predicate1 = Predicates.Field<SysUserAuth>(p => p.Openid, Operator.Eq, openid);
            IPredicate predicate2 = Predicates.Field<SysUserAuth>(p => p.AccessToken, Operator.Eq, token);
            IPredicateGroup group1 = Predicates.Group(GroupOperator.And, predicate1,predicate2);
            SysUserAuth userAuth1 = _sysUserAuthService.GetFirstOrDefault(group1);
            if (userAuth1==null)
            {
                return UserLoginResults.WrongPassword;
            }
            else
            {
                return UserLoginResults.Successful;
            }


        }

        #endregion

    }
}
