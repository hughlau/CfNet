using CfNet.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/12/26 17:15:50
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Core.Domain
{
    [Serializable]
    public partial class SysPage : BaseEntity
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public int MenuId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int IsValid { get; set; }
        public string CreateTime { get; set; }
    }
}
