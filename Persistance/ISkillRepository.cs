using LearnASkill.Models;

namespace LearnASkill.Persistance;

public interface ISkillRepository
{
    Task<List<Skill>> GetAll(string? name, CancellationToken cancellationToken);
    Task<Skill> GetById(int id, CancellationToken cancellationToken);
    Task<Skill> Update(int id, Skill skill, CancellationToken cancellationToken);
    Task<Skill> Add(Skill skill, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);
}
