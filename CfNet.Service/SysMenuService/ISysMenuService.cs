﻿using CfNet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfNet.Service.SysMenuService
{
    public partial interface ISysMenuService
    {
        IList<SysMenu> GetAll();
    }
}
