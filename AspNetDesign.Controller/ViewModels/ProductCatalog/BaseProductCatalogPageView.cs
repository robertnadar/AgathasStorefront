using AspNetDesign.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesignController.ViewModels.ProductCatalog
{
    public abstract class BaseProductCatalogPageView
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}
