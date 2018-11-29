using CfNet.Core.Data;
using CfNet.Core.Infrastructure.Engine;
using CfNet.Core.Infrastructure.HandleException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/29 9:09:00
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Core.Infrastructure.StartupTask
{
    public class DbStartupTask:IStartupTask
    {
        #region Field
        #endregion

        #region Ctor
        #endregion

        #region Method

        public void Execute()
        {
            //var settings = EngineContext.Current.Resolve<DataSettings>();
            //if (settings != null && settings.IsValid())
            //{
            //    var provider = EngineContext.Current.Resolve<IDataProvider>();
            //    if (provider == null)
            //        throw new CustomException("No IDataProvider found");
            //    provider.SetDatabaseInitializer();
            //}
        }

        public int Order
        {
            //ensure that this task is run first 
            get { return -1000; }
        }

        #endregion
    }
}
