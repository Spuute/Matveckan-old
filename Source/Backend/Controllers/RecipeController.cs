using System;
using Backend.Models;
using Backend.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly FoodWeekContext _dbContext;

        public RecipeController(FoodWeekContext dbContext) {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetRecipes(){
            var allRecipes = _dbContext.Recipes.Select(x => x.Name).ToList();
            return Ok(allRecipes);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipe(int id){
           var dish = _dbContext.Recipes
                    .Join(_dbContext.RecipeIngredients,
                    r => r.Id,
                    ir => ((byte)ir.RecipeId),
                    (r, ir) => new {
                        r.Name,
                        r.Category,
                        i = ir.Ingredient.Name,
                        ir.Ingredient.Amount,
                        ir.Ingredient.Weight
                    })
                    .Select(r => new {
                        Dish = r.Name,
                        Ingredients = new {
                            Ingredient = r.i,
                            Amount = r.Amount,
                            Weight = r.Weight
                        }
                    }).ToList();

            return Ok(dish);
        }

        [HttpPost]
        public IActionResult AddRecipe([FromBody] Recipe recipe) {
            try {
            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();
            return Ok("Recept tillagt i databasen.");
            }
            catch {
                return Conflict();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id){
            var recipe = _dbContext.Recipes.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(recipe);
            _dbContext.SaveChanges();
            return Ok("Recept borttaget");
        }
    }
}