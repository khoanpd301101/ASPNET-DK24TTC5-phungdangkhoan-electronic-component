using System.ComponentModel.DataAnnotations;

namespace electronic_component.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Địa chỉ nhận hàng không được để trống")]
        public string ShippingAddress { get; set; }

        public string? Note { get; set; }
    }
}