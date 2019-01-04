using System.ComponentModel.DataAnnotations;

namespace CfNet.Admin.Models.Menu
{
    public class SysMenuEditModel
    {
        public int MenuId { get; set; }

        [Required(ErrorMessage = "菜单不能为空")]
        [Display(Name = "菜单：")]
        public string MenuName { get; set; }

        [Required(ErrorMessage = "地址不能为空")]
        [Display(Name = "Url：")]
        public string Url { get; set; }


        private int _status;
        /// <summary>
        /// 0：有效；1：无效
        /// </summary>
        [Display(Name = "是否有效：")]
        public bool Status { get => _status == 0; set => _status = value ? 0 : 1; }
    }
}