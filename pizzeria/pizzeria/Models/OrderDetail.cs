using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    public partial class OrderDetail
    {
        [Key]
        [Column("Id_Product")]
        public int IdProduct { get; set; }
        [Key]
        [Column("Id_Order")]
        public int IdOrder { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [ForeignKey("IdOrder")]
        [InverseProperty("OrderDetails")]
        public virtual Order IdOrderNavigation { get; set; } = null!;
        [ForeignKey("IdProduct")]
        [InverseProperty("OrderDetails")]
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
