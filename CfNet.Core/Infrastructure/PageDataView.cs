using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfNet.Core.Infrastructure
{
    public partial class PageDataView<T>
    {
        private int _TotalNum;
        public PageDataView()
        {
            this._Items = new List<T>();
        }
        public int total
        {
            get { return _TotalNum; }
            set { _TotalNum = value; }
        }
        private IList<T> _Items;
        public IList<T> rows
        {
            get { return _Items; }
            set { _Items = value; }
        }
        public int CurrentPage { get; set; }
        public int TotalPageCount { get; set; }
    }
}
