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
        [DisplayName("Account.Login.Fields.UserName")]
        [AllowHtml]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Account.Login.Fields.Password")]
        [AllowHtml]
        public string Password { get; set; }

        [DisplayName("Account.Login.Fields.RememberMe")]
        public bool RememberMe { get; set; }

        public string Message { get; set; }
    }
}