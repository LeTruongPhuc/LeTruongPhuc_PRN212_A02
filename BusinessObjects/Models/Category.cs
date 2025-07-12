using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(40)]
        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public byte[]? Picture { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}