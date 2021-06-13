using System.Collections.Generic;
using Backend.Models;

namespace Backend.Interfaces
{
        public interface IIngredient
    {
        int Id { get; set; }
        string IngredientName { get; set; }
        string Amount { get; set; }
        ICollection<IngredientRecipe> IngredientRecipes { get; set; }
    }
}