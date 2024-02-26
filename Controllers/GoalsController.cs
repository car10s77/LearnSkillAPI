using LearnASkill.Models;
using LearnASkill.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnASkill.Controllers;

[Route("api/v{apiVersion}/{skillId}/[controller]")]
[ApiVersion("1.0")]
[Authorize]
[ApiController]
public class GoalsController : ControllerBase
{
    private IGoalRepository _goalRepository;

    public GoalsController(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }
    // GET: api/<GoalsController>
    [HttpGet("/api/v{apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var result = await _goalRepository.GetAll(pageNumber, pageSize, cancellationToken);

        return Ok(new { result.PaginationMetadata, Goals = result.Goals });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddGoals([FromBody] List<Goal> goals, int skillId, CancellationToken cancellationToken)
    {
        var result = await _goalRepository.Add(skillId, goals, cancellationToken);
        return result != null ? 
            CreatedAtAction(nameof(AddGoals), result) : 
            BadRequest();
    }
}
