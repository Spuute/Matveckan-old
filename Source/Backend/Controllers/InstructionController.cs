using System;
using Backend.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructionsController : ControllerBase
    {
        private readonly FoodWeekContext _dbContext;
        public InstructionsController(FoodWeekContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("for-recipe/Ins{id}")]
        public IActionResult InstructionsForRecipe(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("to-recipe/{id}")]
        public IActionResult AddStep()
        {
            throw new NotImplementedException();
        }
    }
}