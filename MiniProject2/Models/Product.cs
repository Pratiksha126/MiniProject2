using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject2.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Display(Name ="Image")]
        public string? ImageURL { get; set; }
       
        public int CategoryId { get; set; }
        

        [ForeignKey("CategoryId")]

        public virtual Category Category { get; set; }

        [Required]
        public int Discount { get; set; }
        [Required]
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public int Stock { get; set; }


    }
}
