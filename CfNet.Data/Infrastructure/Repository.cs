
using System;
using System.Collections.Generic;
using System.Data;
using CfNet.Core.Infrastructure;
using Dapper;
using DapperExtensions;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using CfNet.Core.Data;
using CfNet.Core.Domain.Base;

namespace CfNet.Data.Infrastructure
{
    public partial class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        #region Field

        private IDataProviderManager _dataProviderManager;

        #endregion


        #region Ctor

        public Repository(IDataProviderManager dataProviderManager)
        {
            this._dataProviderManager = dataProviderManager;
        }

        #endregion


        #region Method

        private IDbConnection GetConn()
        {
            var connection = _dataProviderManager.LoadDataProvider().GetDbConnection();
            connection.Open();
            return connection;
        }


        public T GetModelByMainKey(int id)
        {
            using (IDbConnection conn = GetConn())
            {
                return conn.Get<T>(id);
            }
        }

        public IList<T> GetModels(IPredicateGroup predGroup, IList<ISort> sortlist = null)
        {
            using (IDbConnection conn = GetConn())
            {
                return conn.GetList<T>(predGroup,sortlist).ToList<T>();
            }
        }

        public IList<T> GetModelByPage(IPredicateGroup predGroup, int pageIndex, int pageSize, IList<ISort> sortlist = null)
        {
            using (IDbConnection conn= GetConn())
            {
                return conn.GetPage<T>(predGroup, sortlist, pageIndex, pageSize).ToList<T>();
            }
        }

        public int Count(IPredicateGroup predGroup)
        {
            using (IDbConnection conn = GetConn())
            {
                return conn.Count<T>(predGroup);
            }
        }

        public T GetFirstOrDefault(IPredicateGroup predGroup)
        {
            using (IDbConnection conn = GetConn())
            {
                return conn.GetList<T>(predGroup).FirstOrDefault();
            }
        }

        public dynamic Insert(T model)
        {
            using (IDbConnection conn=GetConn())
            {
                dynamic mk= conn.Insert<T>(model);
                return mk;
            }
        }

        public void Inserts(IEnumerable<T> models)
        {
            using (IDbConnection conn=GetConn())
            {
                conn.Insert<T>(models);
            }
        }

        public void Update(T model)
        {
            using (IDbConnection conn = GetConn())
            {
                conn.Update<T>(model);
            }
        }

        public void Delete(T model)
        {
            using (IDbConnection conn = GetConn())
            {
                conn.Delete<T>(model);
            }
        }

        public void DeleteByWhere(IPredicateGroup predGroup)
        {
            using (IDbConnection conn = GetConn())
            {
                conn.Delete<T>(predGroup);
            }
        }
        #endregion


    }
}
