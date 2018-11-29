using CfNet.Core.Data.Infrastructure;
using CfNet.Core.Infrastructure.HandleException;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/****************************************************************
*   Author：L
*   Time：2018/11/29 9:49:07
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Core.Data
{
    public class DataProviderManager : IDataProviderManager
    {
        #region Field

        /// <summary>
        /// Gets or sets settings
        /// </summary>
        protected DataSettings Settings { get; private set; }

        #endregion

        #region Ctor
        #endregion

        #region Method

        public IDataProvider LoadDataProvider()
        {
            var dataSettingManager = new DataSettingsManager();
            Settings = dataSettingManager.LoadSettings();
            var providerName = Settings.DataProvider;
            if (String.IsNullOrWhiteSpace(providerName))
                throw new CustomException("Data Settings doesn't contain a providerName");

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider(Settings);
                case "mysql":
                    return new MySqlDataProvider(Settings);
                default:
                    throw new CustomException(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }

        #endregion

    }
}
