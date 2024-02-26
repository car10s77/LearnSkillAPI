using System.Text.Json.Serialization;

namespace LearnASkill.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }    
    public string LastName { get; set; }  
    public string UserName { get; set; }
    public string Password { get; set; }
    public string UserEmail { get; set; }
    public string City { get; set; }

    [JsonIgnore]
    public List<UserGoal>? UsersGoals { get; set; }
}
