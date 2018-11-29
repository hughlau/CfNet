using CfNet.Core.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/29 9:51:58
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Core.Data.Infrastructure
{
    public class MySqlDataProvider : IDataProvider
    {
        #region Field

        private DataSettings _settings;

        #endregion

        #region Ctor

        public MySqlDataProvider(DataSettings settings)
        {
            this._settings = settings;
        }

        #endregion

        #region Method

        public bool StoredProceduredSupported => throw new NotImplementedException();

        public bool BackupSupported => throw new NotImplementedException();

        public IDbConnection GetDbConnection()
        {
            return new MySqlConnection(_settings.DataConnectionString);
        }

        public DbParameter GetParameter()
        {
            throw new NotImplementedException();
        }

        public void InitConnectionFactory()
        {
            throw new NotImplementedException();
        }

        public void InitDatabase()
        {
            throw new NotImplementedException();
        }

        public void SetDatabaseInitializer()
        {
            throw new NotImplementedException();
        }

        public int SupportedLengthOfBinaryHash()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
