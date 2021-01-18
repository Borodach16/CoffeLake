using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeLake.Areas.Admin.Models
{
    public class ProductsEditPage
    {
        public Product Products { get; set; }
        public List<ProductCategory> Categories { get; set; }
    }
}