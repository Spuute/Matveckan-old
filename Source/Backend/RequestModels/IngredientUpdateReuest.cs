using Backend.Models;

namespace Backend.RequestModels
{
    public class IngredientUpdateReuest
    {
        public IngredientRecipe IngredientRecipe { get; set; }
        public string IngredientName { get; set; }
        public string IngredientAmount { get; set; }
    }
}