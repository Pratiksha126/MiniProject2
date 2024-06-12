using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject2.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Display(Name ="Upload Image")]
        public string? ImageURL { get; set; }
        [ForeignKey("categoryId")]
        public int CategoryId { get; set; }
        [ScaffoldColumn(false)]

        public string? CategoryName { get; set; }

        public int Discount { get; set; }
        [Required]
        [MaxLength(300)]
        public string? Description { get; set; }
        public int Stock { get; set; }


    }
}
