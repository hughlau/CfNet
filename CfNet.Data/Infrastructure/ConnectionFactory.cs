

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CfNet.Data.Infrastructure
{
    public sealed class ConnectionFactory
    {
        #region Field

        private static readonly ConnectionFactory instance = null;

        public static ConnectionFactory Instance
        {
            get
            {
                return instance;
            }

        }
        #endregion

        #region Ctor

        private ConnectionFactory() { }

        static ConnectionFactory()
        {
            instance = new ConnectionFactory();
        }

        #endregion

        
        #region Method


        public IDbConnection GetConn()
        {
            string strconn= ConfigurationManager.AppSettings["strconn"].ToString();
            return new SqlConnection(strconn);
        }
        

        #endregion
    }
}
