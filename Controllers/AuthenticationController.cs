using LearnASkill.Models;
using LearnASkill.Persistance;
using LearnASkill.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LearnASkill.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AuthenticationController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequestBody credentials, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsername(credentials.UserName, cancellationToken);
        if (user == null)
            return Unauthorized();

        if(AuthenticationService.ValidateCredentials(user, credentials.Password))
            return Ok(new { Token = AuthenticationService.CreateToken(user) });
        else
            return Unauthorized();           
    }

}
