namespace Backend.Models
{
    public class Recipe
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}