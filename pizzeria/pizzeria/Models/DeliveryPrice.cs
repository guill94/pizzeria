using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    [Table("DeliveryPrice")]
    public partial class DeliveryPrice
    {
        public DeliveryPrice()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("Id_DeliveryPrice")]
        public int IdDeliveryPrice { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal DeliveryDistance { get; set; }
        [Column("DeliveryPrice", TypeName = "money")]
        public decimal DeliveryPrice1 { get; set; }
        [Column("Id_DeliveryPriceRules")]
        public int IdDeliveryPriceRules { get; set; }

        [ForeignKey("IdDeliveryPriceRules")]
        [InverseProperty("DeliveryPrices")]
        public virtual DeliveryPriceRule IdDeliveryPriceRulesNavigation { get; set; } = null!;
        [InverseProperty("IdDeliveryPriceNavigation")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
