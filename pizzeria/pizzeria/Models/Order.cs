using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("Id_Order")]
        public int IdOrder { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalPrice { get; set; }
        [Column("Id_DeliveryPrice")]
        public int? IdDeliveryPrice { get; set; }
        [Column("Id_Status")]
        public int IdStatus { get; set; }
        [Column("Id_DeliveryCompany")]
        public int? IdDeliveryCompany { get; set; }
        [Column("Id_Address")]
        public int IdAddress { get; set; }
        [Column("Id_AppUser")]
        [StringLength(250)]
        [Unicode(false)]
        public string IdAppUser { get; set; } = null!;

        [ForeignKey("IdAddress")]
        [InverseProperty("Orders")]
        public virtual Address IdAddressNavigation { get; set; } = null!;
        [ForeignKey("Id")]
        [InverseProperty("Orders")]
        public virtual AppUser IdAppUserNavigation { get; set; } = null!;
        [ForeignKey("IdDeliveryCompany")]
        [InverseProperty("Orders")]
        public virtual DeliveryCompany? IdDeliveryCompanyNavigation { get; set; }
        [ForeignKey("IdDeliveryPrice")]
        [InverseProperty("Orders")]
        public virtual DeliveryPrice? IdDeliveryPriceNavigation { get; set; }
        [ForeignKey("IdStatus")]
        [InverseProperty("Orders")]
        public virtual Status IdStatusNavigation { get; set; } = null!;
        [InverseProperty("IdOrderNavigation")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
