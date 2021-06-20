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

        //TODO: Refactor to Repository
        [HttpGet("for-recipe/{id}")]
        public IActionResult InstructionsForRecipe(int id)
        {
            var test = _dbContext.Recipes
            .Include(x => x.Instructions)
            .Where(x => x.Id == id)
            .Select(i => i.Instructions).ToList();

            return Ok(test);
        }

        //TODO: Refactor to Repository and naming
        [HttpPost("to-recipe/{id}")]
        public IActionResult AddStep([FromBody] AddInstructionRequest instruction, int id)
        {
            var test = _dbContext.Recipes
                        .Include(x => x.Instructions)
                        .Where(x => x.Id == id).FirstOrDefault();

            var newInstruction = new Instruction();
            newInstruction.Step = instruction.Step;
            newInstruction.StepNumber = instruction.StepNumber;

            var same = test.Instructions.Where(x => x.StepNumber == newInstruction.StepNumber);

            if (same == null)
            {
                test.Instructions.Add(newInstruction);
                _dbContext.SaveChanges();
                return Ok("Instruktion tillagd till receptet");
            }

            return BadRequest("Det finns redan en instruktion med samma nummer på för steg");
        }
    }
}