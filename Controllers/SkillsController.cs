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
public class SkillsController : ControllerBase
{
    private ISkillRepository _skillRepository;

    public SkillsController(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(string? name, CancellationToken cancellationToken)
    {
        var skills = await _skillRepository.GetAll(name, cancellationToken);
        return skills != null ? Ok(skills) : NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetById(id, cancellationToken);
        return skill != null ? Ok(skill) : NotFound();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody] Skill skill, int id, CancellationToken cancellationToken)
    {
        var _skill = await _skillRepository.Update(id, skill, cancellationToken);
        return _skill != null ? Ok(skill) : NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Add([FromBody] Skill skill, CancellationToken cancellationToken)
    {
        var _skill = await _skillRepository.Add(skill, cancellationToken);
        return _skill != null ? Created(nameof(Add), new { Skill = _skill }) : NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        return await _skillRepository.Delete(id, cancellationToken) ?
            NoContent() :
            NotFound();
    }
}