using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
            IdAppUsers = new HashSet<AppUser>();
        }

        [Key]
        [Column("Id_Address")]
        public int IdAddress { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string AddressesStreet { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string AdressesCity { get; set; } = null!;
        [StringLength(12)]
        [Unicode(false)]
        public string AddressesZipCode { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string AddressesCountry { get; set; } = null!;

        [InverseProperty("IdAddressNavigation")]
        public virtual ICollection<Order> Orders { get; set; }

        [ForeignKey("IdAddress")]
        [InverseProperty("IdAddresses")]
        public virtual ICollection<AppUser> IdAppUsers { get; set; }
    }
}
