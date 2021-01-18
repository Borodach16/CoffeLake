using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeLake.Areas.Admin.Models
{
    public class MenuCafeEditPage
    {
        public CoffeLakeMenu CoffeLakeMenu { get; set; }
        public List<MenuCategory> Categories { get; set; }
    }
}