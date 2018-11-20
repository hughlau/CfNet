using Dapper.Contrib.Extensions;

namespace CfNet.Core.Domain
{
    [Table("Sys_Menu")]
    public partial class SysMenu
    {
        [Key]
        public string MenuId { get; set; }

        public string MenuName { get; set; }

        public string MenuLevel { get; set; }

        public string ParentID { get; set; }

        public string Url { get; set; }

        public string Seq { get; set; }

        public string CreateTime { get; set; }

        public string CreateUser { get; set; }

        public string UpdateTime { get; set; }

        public string UpdateUser { get; set; }
    }
}
