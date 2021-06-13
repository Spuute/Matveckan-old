namespace Backend.Interfaces

{
    public interface IInstruction
    {
        int Id { get; set; }
        string Step { get; set; }
        int StepNumber { get; set; }
    }
}