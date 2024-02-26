namespace LearnASkill.Models;

public class Skill
{
    public int Id { get; set; }
    public  required string Name { get; set; }
    public required string Description { get; set; }
    public List<Goal>? Goals { get; set; } = new List<Goal>();
}
