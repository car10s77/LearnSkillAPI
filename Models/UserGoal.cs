using System.Text.Json.Serialization;

namespace LearnASkill.Models;

public class UserGoal
{
    [JsonIgnore]
    public int Id { get; set; }
    public int UserId { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
    public int GoalId { get; set; }    
    public Goal? Goal { get; set; }
    public DateTime? InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }
    public bool Completed { get; set; }
    public DateTime? Deadline { get; set; }
}
