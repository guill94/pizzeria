using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    [Table("Status")]
    [Index("StatusName", Name = "AK_Status", IsUnique = true)]
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("Id_Status")]
        public int IdStatus { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string StatusName { get; set; } = null!;

        [InverseProperty("IdStatusNavigation")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
