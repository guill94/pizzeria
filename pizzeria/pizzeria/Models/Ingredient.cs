using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Models
{
    [Index("IngredientName", Name = "AK_Ingredients", IsUnique = true)]
    public partial class Ingredient
    {
        public Ingredient()
        {
            IdProducts = new HashSet<Product>();
        }

        [Key]
        [Column("Id_Ingredient")]
        public int IdIngredient { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string IngredientName { get; set; } = null!;

        [ForeignKey("IdIngredient")]
        [InverseProperty("IdIngredients")]
        public virtual ICollection<Product> IdProducts { get; set; }
    }
}
