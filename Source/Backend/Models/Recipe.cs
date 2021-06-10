using System.Collections;
using System.Collections.Generic;

namespace Backend.Models
{
    public class Recipe
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public Category Category { get; set; }
        public ICollection<Instruction> Instructions { get; set; }
        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
    }
}