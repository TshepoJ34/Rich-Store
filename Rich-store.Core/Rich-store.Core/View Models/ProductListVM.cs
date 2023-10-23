using Rich_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rich_store.Core.View_Models
{
    public class ProductListVM
    {
        public IEnumerable<ProductListVM> Products { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
