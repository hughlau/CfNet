

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CfNet.Data.Infrastructure
{
    public sealed class ConnectionFactory
    {
        #region Field

        private static readonly ConnectionFactory instance = null;

        public SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["strconn"].ToString());

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



        

        #endregion
    }
}
