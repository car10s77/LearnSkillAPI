using LearnASkill.Exeptions;
using LearnASkill.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnASkill.Persistance;

public class SkillRepository : ISkillRepository
{
    #region comented In Memory db
    //private readonly DataManager<Skill> SkillManager;
    //private readonly DataManager<Goal> GoalManager;

    //public SkillRepository( DataManager<Skill> skillManager, DataManager<Goal> goalManager)
    //{
    //    SkillManager = skillManager;
    //    GoalManager = goalManager;
    //}

    //public List<Skill> GetAll(string? name)
    //{
    //    var skills = SkillManager.GetALL();
    //    NotFoundException.ThrowIfNull(skills);
    //    if (!string.IsNullOrWhiteSpace(name))
    //        return skills.Where(s => s.Name.Contains(name)).ToList();

    //    return skills;
    //}

    //public Skill GetById(int id)
    //{
    //    var result = SkillManager.GetById(id);
    //    NotFoundException.ThrowIfNull(result);
    //    return result;
    //}

    //public Skill Update(int id, Skill skill)
    //{
    //    return SkillManager.Update(id, skill);
    //}

    //public Skill Add(Skill skill)
    //{
    //    int lastId = SkillManager.GetLastId();
    //    skill.Id = lastId + 1;

    //    int lastGoalId = GoalManager.GetLastId();
    //    skill.Goals.ForEach(g =>
    //    {
    //        g.Id = lastGoalId + 1;
    //        lastGoalId = g.Id;
    //        g.SkillId = skill.Id;
    //        GoalManager.Add(g);
    //    });
    //    return SkillManager.Add(skill);
    //}

    //public bool Delete(int id)
    //{
    //    var _skill = GetById(id);
    //    if (_skill != null)
    //    {
    //        SkillManager.Remove(_skill);
    //        return true;
    //    }
    //    else
    //        return false;
    //}

    #endregion
    private readonly AppContext _context;

    public SkillRepository(AppContext context)
    {
        _context = context;
    }
    public async Task<List<Skill>> GetAll(string? name, CancellationToken cancellationToken)
    {
        var skills = await _context.Skills
            .AsNoTracking()
            .Select(s => new Skill
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Goals = s.Goals
            })
            .ToListAsync();

        if (!string.IsNullOrWhiteSpace(name))
            return skills.Where(s => s.Name.Contains(name)).ToList();

        return skills;
    }

    public async Task<Skill> Add(Skill skill, CancellationToken cancellationToken)
    {
        await _context.Skills.AddAsync(skill);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var _skill = await _context.Skills
           .Select(s => new Skill
           {
               Id = s.Id,
               Name = s.Name,
               Description = s.Description,
               Goals = s.Goals
           })
           .FirstOrDefaultAsync(s => s.Id == id);
        NotFoundException.ThrowIfNull(_skill);

        var _DeleteSkill = _context.Skills.Remove(_skill);
        await _context.SaveChangesAsync() ;
        return _DeleteSkill != null ? true: false;
    }


    public async Task<Skill> GetById(int id, CancellationToken cancellationToken)
    {
        var _skill = await _context.Skills
            .AsNoTracking()
            .Select(s => new Skill
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Goals = s.Goals
            })
            .FirstOrDefaultAsync(s => s.Id == id);
        NotFoundException.ThrowIfNull(_skill);

        return _skill;
    }

    public async Task<Skill> Update(int id, Skill skill, CancellationToken cancellationToken)
    {
        var _skill = await _context.Skills
            .Select(s => new Skill
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Goals = s.Goals
            })
            .FirstOrDefaultAsync(s => s.Id == id);
        NotFoundException.ThrowIfNull(_skill);

        _skill.Name = skill.Name;
        _skill.Description = skill.Description;
        _skill.Goals = skill.Goals;
        _context.Skills.Update(_skill);

        await _context.SaveChangesAsync();

        return _skill;

    }
}
