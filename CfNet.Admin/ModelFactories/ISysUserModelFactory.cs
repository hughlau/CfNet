using CfNet.Admin.Models.SysUser;
using CfNet.Core.Domain.SysUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfNet.Admin.ModelFactories
{
    public interface ISysUserModelFactory
    {
        SysUserEditModel PrepareUser(SysUser user, SysUserAuth userAuth);
    }
}
