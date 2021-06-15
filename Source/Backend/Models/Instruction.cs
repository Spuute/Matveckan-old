using Backend.Interfaces;

namespace Backend.Models
{
    public class Instruction : IInstruction
    {
        public int Id { get; set; }
        public string Step { get; set; }
        public int StepNumber { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}