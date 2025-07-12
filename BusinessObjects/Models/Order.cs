using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required]
        [StringLength(5)]
        public string CustomerID { get; set; } = string.Empty;

        public int EmployeeID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee? Employee { get; set; }

        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}