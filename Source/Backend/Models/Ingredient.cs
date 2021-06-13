using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Backend.Interfaces;

namespace Backend.Models
{
    public class Ingredient : IIngredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public string Amount { get; set; }
        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
    }
}