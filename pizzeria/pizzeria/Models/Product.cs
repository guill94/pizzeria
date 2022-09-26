using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    [Index("ProductName", Name = "AK_Products", IsUnique = true)]
    public partial class Product
    {
        public Product()
        {
            CarItems = new HashSet<CarItem>();
            OrderDetails = new HashSet<OrderDetail>();
            IdIngredients = new List<Ingredient>();
        }

        [Key]
        [Column("Id_Product")]
        public int IdProduct { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string ProductName { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string ProductDescription { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string ProductImageName { get; set; } = null!;
        [Column("Id_Category")]
        public int IdCategory { get; set; }

        [NotMapped]
        [Display(Name = "Ajouter image")]
        public IFormFile ProductImageFile { get; set; }

        [ForeignKey("IdCategory")]
        [InverseProperty("Products")]
        public virtual Category IdCategoryNavigation { get; set; } = null!;
        [InverseProperty("IdProductNavigation")]
        public virtual ICollection<CarItem> CarItems { get; set; }
        [InverseProperty("IdProductNavigation")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [ForeignKey("IdProduct")]
        [InverseProperty("IdProducts")]
        public virtual List<Ingredient> IdIngredients { get; set; }

    }
}
