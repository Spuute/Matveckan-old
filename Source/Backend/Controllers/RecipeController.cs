using System;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Recipes(){
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult Recipe(int id){
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Recipe([FromBody] Recipes recipe){
            try {
            _dbContext.Recipe.Add(recipe);
            return Ok("Recept tillagt i databasen.")
            }
            catch {
                return Conflict();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Recipes(int id){
            throw new NotImplementedException();
        }
    }
}