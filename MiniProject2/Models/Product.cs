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
        public int categoryId { get; set; }
        [ScaffoldColumn(false)]

        public string? categoryName { get; set; }

        public int discount { get; set; }
        [Required]
        [MaxLength(300)]
        public string? description { get; set; }
        public int stock { get; set; }


    }
}
