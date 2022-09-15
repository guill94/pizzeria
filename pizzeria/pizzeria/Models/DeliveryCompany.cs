using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    public partial class DeliveryCompany
    {
        public DeliveryCompany()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("Id_DeliveryCompany")]
        public int IdDeliveryCompany { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CompanyName { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string? CompanyAddress { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? CompanyZip { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CompanyCity { get; set; }

        [InverseProperty("IdDeliveryCompanyNavigation")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
