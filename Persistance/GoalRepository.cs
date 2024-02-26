using LearnASkill.Exeptions;
using LearnASkill.Models;
using LearnASkill.Utils;
using Microsoft.EntityFrameworkCore;

namespace LearnASkill.Persistance;

public class GoalRepository : IGoalRepository
{
    #region comented
    //private readonly DataManager<Goal> GoalManager;
    //private readonly DataManager<Skill> SkillManager;

    //public GoalRepository(DataManager<Goal> goalManager, DataManager<Skill> skillManager)
    //{
    //    GoalManager = goalManager;
    //    SkillManager = skillManager;
    //}
    //public (List<Goal> Goals, PaginationMetadata PaginationMetadata) GetAll(int pageNumber, int pageSize)
    //{
    //    var _goals = GoalManager.GetALL();
    //    var totalItemCount = _goals.Count;
    //    var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

    //    var collection = _goals.Skip(pageSize * (pageNumber - 1))
    //        .Take(pageSize)
    //        .ToList();

    //    return (collection, paginationMetadata);
    //}

    //public List<Goal>? Add(int skillId, List<Goal> goals)
    //{
    //    Skill _skill = SkillManager.GetById(skillId);
    //    NotFoundException.ThrowIfNull(_skill);

    //    int lastGoalId = GoalManager.GetLastId();
    //    goals.ForEach(g =>
    //    {
    //        g.Id = lastGoalId + 1;
    //        lastGoalId = g.Id;
    //        g.SkillId = skillId;
    //        GoalManager.Add(g);
    //    });
    //    return goals;
    //}
    #endregion
    private readonly AppContext _context;

    public GoalRepository(AppContext context)
    {
        _context = context;
    }

    public async Task<List<Goal>> Add(int skillId, List<Goal> goals, CancellationToken cancellationToken)
    {
        var _skill = await _context.Skills
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == skillId);
        NotFoundException.ThrowIfNull(_skill);

        var newGoals = goals.Select(g => new Goal
        {
            Name = g.Name,
            Dificulty = g.Dificulty,
            SkillId = skillId,
        });

        await _context.Goals.AddRangeAsync(newGoals);
        await _context.SaveChangesAsync();

        return newGoals.ToList();
    }

    public async Task<(List<Goal> Goals, PaginationMetadata PaginationMetadata)> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var _goals = await _context.Goals
            .AsNoTracking()
            .ToListAsync();

        var totalItemCount = _goals.Count;
        var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

        var collection = _goals.Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (collection, paginationMetadata);
    }
}
