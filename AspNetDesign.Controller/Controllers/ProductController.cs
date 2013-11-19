using AspNetDesign.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesignController.Controllers
{
    public class ProductController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productService;
        public ProductController(IProductCatalogService productService) : base(productService)
        {
            _productService = productService;
        }
    }
}
