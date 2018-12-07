using CfNet.Core.Domain.Dict;
using CfNet.Core.Domain.SysUser;
using CfNet.Data.Infrastructure;
using CfNet.Service.BaseService;
using DapperExtensions;
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

        public void UpdateAuth(SysUserAuth sysUserAuth)
        {
            IList<IPredicate> predList = new List<IPredicate>();
            predList.Add(Predicates.Field<SysUserAuth>(p => p.AuthType, Operator.Eq, (int)DictSysUserAuth.loginname));
            predList.Add(Predicates.Field<SysUserAuth>(p => p.UserId, Operator.Eq, sysUserAuth.UserId));
            IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, predList.ToArray());

            SysUserAuth model = _repository.GetFirstOrDefault(predGroup);
            if (null==model)
            {
                Add(sysUserAuth);
            }
            else
            {
                model.Openid = sysUserAuth.Openid;
                model.AccessToken = sysUserAuth.AccessToken;

                _repository.Update(model);
            }
            
        }

        #endregion

    }
}
