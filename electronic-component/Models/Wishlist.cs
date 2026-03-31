using System.ComponentModel.DataAnnotations;

namespace electronic_component.Models
{
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}