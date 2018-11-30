using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CfNet.Admin.Models.SysUser
{
    public class SysUserEditModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// 0：有效；1：无效
        /// </summary>
        public int IsExist { get; set; }
    }
}