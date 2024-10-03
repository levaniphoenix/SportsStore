using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly int PageSize = 4;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index(string? category, int productPage = 1)
        {
            var products = (await productService.GetAllAsync()).Where(p => category == null || p.Category == category);
            var productListView = new ProductsListViewModel { Products = products.Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = productPage, ItemsPerPage = PageSize, TotalItems = products.Count() },
                CurrentCategory = category} ;
            return View(productListView);
        }
    }
}
