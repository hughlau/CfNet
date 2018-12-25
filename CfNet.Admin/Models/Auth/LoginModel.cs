using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfNet.Admin.Models.Auth
{
    public class LoginModel
    {

        [Required(ErrorMessage = "账号不能为空")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "用户名长度3-200之间")]
        public string Username { get; set; }

        
        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}