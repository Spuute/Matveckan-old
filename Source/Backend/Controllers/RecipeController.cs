using System;
using Backend.Models;
using Backend.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Resources;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly FoodWeekContext _dbContext;
        private readonly IMapper _mapper;

        public RecipeController(FoodWeekContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetRecipes(){
            var allRecipes = _dbContext.Recipes.Select(x => x.Name).ToList();
            return Ok(allRecipes);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipe(int id){
            //FIXME: Clean up the mess in this method. 
            //TODO: Refactoring.

        //    var dish = _dbContext.Recipes
        //             .Join(_dbContext.RecipeIngredients,
        //             r => r.Id,
        //             ir => ((byte)ir.RecipeId),
        //             (r, ir) => new {
        //                 r.Name,
        //                 r.Category,
        //                 i = ir.Ingredient.Name,
        //                 ir.Ingredient.Amount,
        //                 ir.Ingredient.Weight
        //             })
        //             .Select(r => new {
        //                 Dish = r.Name,
        //                 Ingredients = new {
        //                     Ingredient = r.i,
        //                     Amount = r.Amount,
        //                     Weight = r.Weight
        //                 }
        //             }).ToList();

            var dish1 = _dbContext.Recipes
                        .Where(x => x.Id == id)
                        .Include(e => e.IngredientRecipes)
                        .ThenInclude(e => e.Ingredient)
                        .Select(x => new {
                            dish = x.Name,
                            ingredients = x.IngredientRecipes
                        });
            // var resource = _mapper.Map<Recipe, RecipeResource>(dish1);
            
            return Ok(dish1);
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