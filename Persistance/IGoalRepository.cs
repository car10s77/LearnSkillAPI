using LearnASkill.Models;
using LearnASkill.Utils;

namespace LearnASkill.Persistance;

public interface IGoalRepository
{
    Task<(List<Goal> Goals, PaginationMetadata PaginationMetadata)> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<List<Goal>> Add(int skillId, List<Goal> goals, CancellationToken cancellationToken);
}
