using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LearnASkill.Models;

public class Goal
{
    [JsonIgnore]
    public int Id { get; set; }

    [Required(ErrorMessage = "Field required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 30 characters")]
    public required string Name { get; set; }
    [JsonIgnore]
    public Skill? Skill { get; set; }

    [Required(ErrorMessage = "Field required")]
    public int SkillId { get; set; }

    [Required(ErrorMessage = "Field required")]
    public int Dificulty { get; set; }
    [JsonIgnore]
    public List<UserGoal>? UsersGoals { get; set; }
}
