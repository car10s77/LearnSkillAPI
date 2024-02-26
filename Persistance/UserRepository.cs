using LearnASkill.Exeptions;
using LearnASkill.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnASkill.Persistance;

public class UserRepository : IUserRepository
{
    private readonly AppContext _context;

    public UserRepository(AppContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        NotFoundException.ThrowIfNull(user);
        return user;
    }

    public async Task<UserGoal> AssingUserGoal(UserGoal? userGoal, int userId, int goalId, CancellationToken cancellationToken)
    {
        var _user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userId);
        NotFoundException.ThrowIfNull(_user, "User was not found");

        var _goal = await _context.Goals
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == goalId);
        NotFoundException.ThrowIfNull(_goal, "Goal was not found");

        userGoal ??= new UserGoal();

        userGoal.UserId = userId;
        userGoal.GoalId = goalId;
        userGoal.Completed = false;

        await _context.UsersGoals.AddAsync(userGoal);
        await _context.SaveChangesAsync();

        return userGoal;
    }

    public async Task<List<UserGoal>> GetUserGoals(int userId, CancellationToken cancellationToken)
    {
        var _user = await _context.Users
           .AsNoTracking()
           .FirstOrDefaultAsync(u => u.Id == userId);
        NotFoundException.ThrowIfNull(_user, "User was not found");

        var _UserGoals = await _context.UsersGoals
            .AsNoTracking()
            .Where(ug => ug.UserId == userId)
            .Select(ug => new UserGoal
            {
                UserId = ug.UserId,
                InitialDate = ug.InitialDate,
                FinalDate = ug.FinalDate,
                Completed = ug.Completed,
                GoalId = ug.GoalId,
                Goal = ug.Goal,
            })
            .ToListAsync();

        return _UserGoals;
    }
}
