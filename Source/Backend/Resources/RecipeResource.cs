using System.Collections.Generic;
using Backend.Models;

namespace Backend.Resources
{
    public class RecipeResource
    {
        public Category Categories { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}