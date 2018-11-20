
using System.Collections.Generic;
using System.Data;
using Dapper.Contrib.Extensions;

namespace CfNet.Data.Infrastructure
{
    public partial class Repository<T> : IRepository<T> where T : class, new()
    {
        #region Field


        #endregion


        #region Ctor


        #endregion


        #region Method

        private IDbConnection GetConn()
        {
            var connection = ConnectionFactory.Instance.GetConn();
            connection.Open();
            return connection;
        }


        public T GetModelByMainKey(int id)
        {
            using (var conn = GetConn())
            {
                return conn.Get<T>(id);
            }
        }

        public IList<T> GetAll()
        {
            using (var conn=GetConn())
            {
                return conn.GetAll<T>();
            }
        }
        #endregion


    }
}
