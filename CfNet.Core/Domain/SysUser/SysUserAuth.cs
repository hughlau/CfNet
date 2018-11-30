using CfNet.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/30 10:46:36
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Core.Domain.SysUser
{
    public class SysUserAuth:BaseEntity
    {
        #region Field


        public int AuthId { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// 0：loginname；1：mobile，2：email，3：wechat，4：weibo，5：qq
        /// </summary>
        public int AuthType { get; set; }
        public string Openid { get; set; }
        public string AccessToken { get; set; }
        public string CreateTime { get; set; }

        #endregion

        #region Ctor
        #endregion

        #region Method
        #endregion
    }
}
