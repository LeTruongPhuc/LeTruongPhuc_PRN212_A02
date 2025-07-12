using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace BusinessObjects.Models
{
    public class Customer
    {
        [Key]
        [StringLength(5)]
        public string CustomerID { get; set; } = string.Empty;

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; } = string.Empty;

        [StringLength(30)]
        public string? ContactName { get; set; }

        [StringLength(30)]
        public string? ContactTitle { get; set; }

        [StringLength(60)]
        public string? Address { get; set; }

        [StringLength(24)]
        public string? Phone { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}