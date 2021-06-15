using Backend.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructionController : ControllerBase
    {
        private readonly FoodWeekContext _dbContext;
        public InstructionController(FoodWeekContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}