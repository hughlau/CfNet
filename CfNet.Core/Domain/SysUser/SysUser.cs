using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/27 17:08:43
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Core.Domain.SysUser
{
    [Serializable]
    public partial class SysUser
    {
        #region Field

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string CreateTime { get; set; }
        public string CreateUser { get; set; }
        public string UpdateTime { get; set; }
        public string UpdateUser { get; set; }

        /// <summary>
        /// 0：有效；1：无效
        /// </summary>
        public int IsExist { get; set; }

        #endregion

        #region Ctor
        #endregion

        #region Method
        #endregion
    }
}
