using Rich_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rich_store.Core.View_Model
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
