using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeLake.Areas.Admin.Models
{
    public class MenuEditPage
    {
        public CoffeLakeMenu Menu { get; set; }
        public List<MenuCategory> Categories { get; set; }
    }
}