using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    public partial class DeliveryPriceRule
    {
        public DeliveryPriceRule()
        {
            DeliveryPrices = new HashSet<DeliveryPrice>();
        }

        [Key]
        [Column("Id_DeliveryPriceRules")]
        public int IdDeliveryPriceRules { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal RulesMaxDistance { get; set; }
        [Column(TypeName = "money")]
        public decimal RulesPrice { get; set; }

        [InverseProperty("IdDeliveryPriceRulesNavigation")]
        public virtual ICollection<DeliveryPrice> DeliveryPrices { get; set; }
    }
}
