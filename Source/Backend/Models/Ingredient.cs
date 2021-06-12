using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public double? Weight { get; set; }
        //TODO: Kolla om detta bör bli något annat
        public string? Amount { get; set; }
        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
    }
}