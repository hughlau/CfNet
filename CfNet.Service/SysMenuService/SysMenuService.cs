using CfNet.Data.Infrastructure;
using CfNet.Core.Domain;

namespace CfNet.Service.SysMenuService
{
    public partial class SysMenuService
    {
        public Repository<SysMenu> repository = new Repository<SysMenu>();

        public SysMenu GetModel(int id)
        {
            return repository.GetModelByKey(id);
        }
    }
}
