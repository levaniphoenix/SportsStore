using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace SportsStore.tests
{
    internal class ProductEqualityComparer : IEqualityComparer<Product?>
    {
        public bool Equals(Product? x, Product? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.ProductID == y.ProductID
                && x.Name == y.Name
                && x.Description == y.Description
                && x.Price == y.Price
                && x.Category == y.Category;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return obj.GetHashCode();
        }
    }
}
