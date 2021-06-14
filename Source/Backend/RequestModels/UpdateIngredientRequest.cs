namespace Backend.RequestModels
{
    public class UpdateIngredientRequest
    {
        public string IngredientName { get; set; }
        public string IngredientAmount { get; set; }
        public string RecipeToUpdate { get; set; }
    }
}