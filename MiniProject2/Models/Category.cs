﻿using System.ComponentModel.DataAnnotations;

namespace MiniProject2.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
    }
}
