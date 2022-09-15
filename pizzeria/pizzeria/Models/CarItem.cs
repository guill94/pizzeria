using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    public partial class CarItem
    {
        [Key]
        [Column("Id_CarItem")]
        public int IdCarItem { get; set; }
        public int? Amount { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string? CartId { get; set; }
        [Column("Id_Product")]
        public int IdProduct { get; set; }

        [ForeignKey("IdProduct")]
        [InverseProperty("CarItems")]
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
