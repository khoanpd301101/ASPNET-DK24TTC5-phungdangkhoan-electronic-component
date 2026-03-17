using System.ComponentModel.DataAnnotations;

namespace electronic_component.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}