using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class OrderDetailModel
    {
        public long OrderID { get; set; }

        public long ProductID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
