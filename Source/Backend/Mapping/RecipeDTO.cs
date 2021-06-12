using System.Collections.Generic;
using Backend.Models;

namespace Backend.Mapping
{
    public class RecipeDTO
    {
        public string Name { get; set; } 
        public Category Categories { get; set; }
        public List<IngredientResource> Ingredients { get; set; }
    }
}