using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace BusinessObjects.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Password { get; set; } = string.Empty;

        [StringLength(30)]
        public string? JobTitle { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? HireDate { get; set; }

        [StringLength(60)]
        public string? Address { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}