using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_component.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; } = 1;

        [NotMapped]
        public decimal TotalPrice => (Product != null) ? Product.Price * Quantity : 0;
    }
}