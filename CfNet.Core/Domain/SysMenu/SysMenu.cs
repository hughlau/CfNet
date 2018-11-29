
using System;
using CfNet.Core.Domain.Base;

namespace CfNet.Core.Domain
{
    [Serializable]
    public partial class SysMenu : BaseEntity
    {

        public int MenuId { get; set; }

        public string MenuName { get; set; }

        public int MenuLevel { get; set; }

        public int ParentID { get; set; }

        public string Url { get; set; }

        public int Seq { get; set; }

        public string CreateTime { get; set; }

        public string CreateUser { get; set; }

        public string UpdateTime { get; set; }

        public string UpdateUser { get; set; }
    }
}
