using DapperExtensions;
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


        IList<T> GetModels(IPredicateGroup predGroup, IList<ISort> sortlist = null);


        IList<T> GetModelByPage(IPredicateGroup predGroup, int pageIndex, int pageSize, IList<ISort> sortlist);


        int Count(IPredicateGroup predGroup);

        T GetFirstOrDefault(IPredicateGroup predGroup);

        dynamic Insert(T model);


        void Inserts(IEnumerable<T> models);


        void Update(T model);


        void Delete(T model);


        void DeleteByWhere(IPredicateGroup predGroup);


        #endregion
    }
}
