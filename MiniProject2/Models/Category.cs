using System.ComponentModel.DataAnnotations;

namespace MiniProject2.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [Required]
        public string? categoryName { get; set; }
    }
}
