using System;
using Backend.Models;
using Backend.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Resources;
using System.Collections.Generic;
using Backend.Services.Repositories;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly FoodWeekContext _dbContext;
        private readonly IRepository<Recipe, int> _recipeRepository;

        public RecipeController(FoodWeekContext dbContext, IRepository<Recipe, int> recipeRepository) {
            _dbContext = dbContext;
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes(){
            return Ok(await _recipeRepository.GetAll());
        }

        //TODO: Add endpoint to randomize recipes for one week.
        // [HttpGet]
        // public async Task<IActionResult> RandomizeRecipes() {
        //     throw new NotImplementedException();
        // }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeById(int id) { 
            return Ok(await _recipeRepository.GetRecipeWithIngredients(id));
        }

        [HttpGet("recipe/{id}")]
        public async Task<IActionResult> GetCompleteRecipe(int id) {
            return Ok(await _recipeRepository.GetCompleteRecipe(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody] Recipe recipe) {
            try {
                await _recipeRepository.Insert(recipe);
                await _recipeRepository.Save();
                return Ok($"{recipe.Name} tillagt i databasen.");
            }
            catch {
                return Conflict();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id) {
            await _recipeRepository.Delete(id);
            await _recipeRepository.Save();
            return Ok("Recept borttaget");
        }
    }
}