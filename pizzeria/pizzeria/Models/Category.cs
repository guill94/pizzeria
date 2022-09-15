using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    [Index("CategoryName", Name = "AK_Categories", IsUnique = true)]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("Id_Category")]
        public int IdCategory { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string CategoryName { get; set; } = null!;

        [InverseProperty("IdCategoryNavigation")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
