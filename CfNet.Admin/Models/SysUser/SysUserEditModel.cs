using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CfNet.Admin.Models.SysUser
{
    public class SysUserEditModel
    {
        
        public int UserID { get; set; }

        [Required(ErrorMessage = "用户名不能为空")]
        [Display(Name = "用户名：")]
        [StringLength(200,MinimumLength =3, ErrorMessage = "用户名长度3-200之间")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "手机号不能为空")]
        [Display(Name = "手机号：")]
        [RegularExpression(@"^[1]+[3,5]+\d{9}", ErrorMessage ="手机号码格式错误")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "邮箱不能为空")]
        [Display(Name = "邮箱：")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",ErrorMessage ="邮箱格式错误")]
        public string Email { get; set; }


        [Display(Name = "账号：")]
        [Required(ErrorMessage = "密码不能为空")]
        public string LoginName { get; set; }

        [Display(Name = "密码：")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="密码不能为空")]
        public string Password { get; set; }

        private int _IsExist;
        /// <summary>
        /// 0：有效；1：无效
        /// </summary>
        [Display(Name = "是否有效：")]
        public bool IsExist { get => _IsExist == 0; set => _IsExist = value ? 0 : 1; }
    }
}