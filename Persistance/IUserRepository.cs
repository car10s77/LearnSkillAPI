using LearnASkill.Models;

namespace LearnASkill.Persistance;

public interface IUserRepository
{
    Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken);

    Task<UserGoal> AssingUserGoal(UserGoal? userGoal, int userId, int goalId, CancellationToken cancellationToken);

    Task<List<UserGoal>> GetUserGoals(int userId, CancellationToken cancellationToken);
}
