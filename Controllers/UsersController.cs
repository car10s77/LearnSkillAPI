using LearnASkill.Models;
using LearnASkill.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnASkill.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Authorize]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository repository)
    {
        _userRepository = repository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AssignUserGoal([FromBody] UserGoal? userGoal,
        int userId,
        int goalId,
        CancellationToken cancellationToken)
    {
        var _userGoal = await _userRepository.AssingUserGoal(userGoal, userId, goalId, cancellationToken);
        return _userGoal != null ? Ok(userGoal) : BadRequest();
    }

    [HttpGet("{userId}/Goals")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetUserGoals(int userId, CancellationToken cancellationToken)
    {
        var _UserGoals = await _userRepository.GetUserGoals(userId, cancellationToken);

        return _UserGoals != null ? Ok(_UserGoals) : NoContent();
    }
}
