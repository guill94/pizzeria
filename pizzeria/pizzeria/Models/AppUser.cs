using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    public partial class AppUser : IdentityUser
    {
        public AppUser()
        {
            Orders = new HashSet<Order>();
            IdAddresses = new HashSet<Address>();
        }

        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;

        [InverseProperty("IdAppUserNavigation")]
        public virtual ICollection<Order> Orders { get; set; }

        [ForeignKey("IdAppUser")]
        [InverseProperty("IdAppUsers")]
        public virtual ICollection<Address> IdAddresses { get; set; }
    }
}
