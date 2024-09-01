using Business.Models;

namespace SportsStore.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductModel> Products { get; set; } = Enumerable.Empty<ProductModel>();
        
        public PagingInfo PagingInfo { get; set; } = new();

        public string? CurrentCategory { get; set; }
    }
}
