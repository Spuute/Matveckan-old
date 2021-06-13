using System.Collections.Generic;
using Backend.Models;

namespace Backend.Interfaces

{
    public interface IRecipe
    {
        int Id { get; set; }
        string Name { get; set; }
        Category Category { get; set; }
        ICollection<Instruction> Instructions { get; set; }
        ICollection<IngredientRecipe> IngredientRecipes { get; set; }
    }
}