using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderDetail
    {
        public long OrderID { get; set; }

        public long ProductID { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }

        public Product Product { get; set; } = default!;

        public Order order { get; set; } = default!;
    }
}
