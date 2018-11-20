using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfNet.Data.Infrastructure
{
    public interface IRepository<T>
    {
        #region Method

        T GetModelByMainKey(int id);



        #endregion
    }
}
