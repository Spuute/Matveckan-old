using Backend.Models;
using Backend.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Backend.RequestModels;
using System.Threading.Tasks;
using Backend.Services.Repositories;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly FoodWeekContext _dbContext;
        private readonly IIngredientRepository _igredientRepository;

        public IngredientController(FoodWeekContext dbContext,
        IIngredientRepository igredientRepository)
        {
            _dbContext = dbContext;
            _igredientRepository = igredientRepository;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Ingredients(int id, [FromBody] AddIngredient addIngredient)
        {
            var ingredient = await _igredientRepository.Insert(addIngredient);
            await _igredientRepository.Save();
            var recipeIngredient = await _igredientRepository.MapToRecipe(ingredient, id);

            if (recipeIngredient != null)
            {
                await _igredientRepository.Save();
                return Ok("Ingrediens tillagd till receptet");
            }

            return BadRequest("Ingrediensen finns redan i detta recept");
        }

        //TODO: Add endpoint for updating ingredient if user misspell or some other error. 
        [HttpPut("{id}/{ingredientName}")]
        public async Task<IActionResult> UpdateIngredient(int id, string ingredientName, [FromBody] AddIngredient addIngredient) {
            var ingredient = await _igredientRepository.Update(addIngredient, ingredientName, id);
            
            if (ingredient != null)
            {
                await _igredientRepository.Save();
                return Ok("Ingrediens uppdaterad");
            }
            return BadRequest("Detta recept har ingen ingrediens med det namnet");
        }

        [HttpDelete("{id}/{ingredientName}")]
        public async Task<IActionResult> Ingredient(int id, string ingredientName)
        {
            var ingredient = _dbContext.Ingredients.Where(x => x.IngredientName == ingredientName).FirstOrDefault();

            if (ingredient != null)
            {
                _dbContext.Ingredients.Remove(ingredient);
                await _dbContext.SaveChangesAsync();
                return Ok("Ingrediensen är borttagen.");
            }
            return BadRequest("Det finns ingen ingrediense med det namnet till detta recept");
        }
    }
}