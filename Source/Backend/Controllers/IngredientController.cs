using System;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        [HttpPost]
        public IActionResult Ingredients(){
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Ingredient(){
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Ingredient(string ingredient){
            throw new NotImplementedException();
        }
    }
}