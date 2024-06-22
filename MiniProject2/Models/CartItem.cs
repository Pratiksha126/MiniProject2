using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniProject2.Models
{
    public class CartItem
    {

        [Key]
        public int CartItemId { get; set; }
        [Required]
        public int CartId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string UserId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountedPrice { get; set; }

        [Range(0, 100, ErrorMessage = "Offer percentage must be between 0 and 100")]
        public int Discount { get; set; }

        [NotMapped]
        public decimal Subtotal => Quantity * DiscountedPrice;

        public Product Product { get; set; }
        public Cart Cart { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

       
    }
}
