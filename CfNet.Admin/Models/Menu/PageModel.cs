using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CfNet.Admin.Models.Menu
{
    public class PageModel
    {
        public int PageId { get; set; }

        [Required(ErrorMessage = "页面名不能为空")]
        [Display(Name = "页面名：")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "页面名长度3-200之间")]
        public string PageName { get; set; }

        public int MenuId { get; set; }

        [Required(ErrorMessage = "路径不能为空")]
        [Display(Name = "路径：")]
        public string Url { get; set; }

        [Required(ErrorMessage = "描述不能为空")]
        [Display(Name = "描述：")]
        public string Description { get; set; }

        [Display(Name = "是否有效：")]
        public bool IsValid { get; set; }

    }
}