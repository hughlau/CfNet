using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CfNet.Admin.Models.Menu
{
    public class TreeModel
    {
        public int id { get; set; }

        public int pId { get; set; }

        public string name { get; set; }
    }
}