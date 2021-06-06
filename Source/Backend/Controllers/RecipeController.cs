using System;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Recipes(){
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult Recipe(int id){
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Recipe(){
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Recipes(int id){
            throw new NotImplementedException();
        }
    }
}