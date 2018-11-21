﻿
using System;
using DapperExtensions;
using DapperExtensions.Mapper;

namespace CfNet.Core.Domain
{
    [Serializable]
    public partial class SysMenu
    {

        public int MenuId { get; set; }

        public string MenuName { get; set; }

        public int MenuLevel { get; set; }

        public int ParentID { get; set; }

        public string Url { get; set; }

        public int Seq { get; set; }

        public DateTime CreateTime { get; set; }

        public string CreateUser { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdateUser { get; set; }
    }
}
