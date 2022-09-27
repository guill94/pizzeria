using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using pizzeria.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pizzeria.Data.ViewModels
{
    public class ProductVM
    {
        public ProductVM()
        {
            IdIngredients = new List<int>();
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
        public virtual ICollection<CartItem> CarItems { get; set; }
        [InverseProperty("IdProductNavigation")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [ForeignKey("IdProduct")]
        [InverseProperty("IdProducts")]
        public virtual List<int> IdIngredients { get; set; }
    }
}
