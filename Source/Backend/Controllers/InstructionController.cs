using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Models.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Backend.RequestModels;

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

        [HttpGet("for-recipe/{id}")]
        public IActionResult InstructionsForRecipe(int id)
        {
            var test = _dbContext.Recipes
            .Include(x => x.Instructions)
            .Where(x => x.Id == id)
            .Select(i => i.Instructions).ToList();

            return Ok(test);
        }

        [HttpPost("to-recipe/{id}")]
        public IActionResult AddStep([FromBody] AddInstructionRequest instruction, int id)
        {
            var test = _dbContext.Recipes
                        .Include(x => x.Instructions)
                        .Where(x => x.Id == id).FirstOrDefault();

            var newInstruction = new Instruction();
            newInstruction.Step = instruction.Step;
            newInstruction.StepNumber = instruction.StepNumber;

            test.Instructions.Add(newInstruction);
            _dbContext.SaveChanges();
            return Ok("Instruktion tillagd till receptet");
        }
    }
}