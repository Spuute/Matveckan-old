using System.Collections;
using System.Collections.Generic;
using Backend.Interfaces;

namespace Backend.Models
{
    public class Recipe : IRecipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public ICollection<Instruction> Instructions { get; set; }
        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
    }
}