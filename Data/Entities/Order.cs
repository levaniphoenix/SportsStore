using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Order
    {
        public long OrderID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string? Line1 { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Line2 { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Line3 { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string? City { get; set; }

        public string? Zip {  get; set; }

        [Required]
        public string? Country { get; set; }

        public bool GiftWrap { get; set; } = false;

        public ICollection<OrderDetail> OrderDetails { get; set; } = default!;
    }
}
