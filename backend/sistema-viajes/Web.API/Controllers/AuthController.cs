using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Users;
using Application.Users.Create;
using Application.Users.GetByEmail;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IMediator _mediator;
    private readonly IHashPassword _hashPassword;

    public AuthController(IConfiguration configuration, IMediator mediator, IHashPassword hashPassword)
    {
        _configuration = configuration;
        _mediator = mediator;
        _hashPassword = hashPassword;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var userResult = await _mediator.Send(new GetUserByEmail(request.Email));

        if (userResult.IsError)
        {
            return Unauthorized(new { message = "Invalid email or password" });
        }

        var user = userResult.Value;

        // Verificar la contraseña
        if (!_hashPassword.Verify(request.Password, user.Password))
        {
            return Unauthorized(new { message = "Invalid email or password" });
        }

        // Generar el token
        var token = GenerateJwtToken(user.Name,user.Email, user.Rol.Value);

        return Ok(new { Token = token });
    }

    private string GenerateJwtToken( string name , string email, string role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {   
                new Claim(ClaimTypes.Name , name),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }


    [HttpPost("register")]
public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
{
    // Validar si el usuario ya existe (opcional)
    var userResult = await _mediator.Send(new GetUserByEmail(request.Email));
    if (!userResult.IsError)
    {
        return BadRequest(new { message = "User already exists" });
    }

    // Crear el comando para crear el usuario
    var createUserCommand = new CreateUserCommand(
        request.Name,
        request.Email,
        request.Password,
        request.Rol
    );

    var result = await _mediator.Send(createUserCommand);

    if (result.IsError)
    {
        return BadRequest(result.Errors);
    }

    return Ok(new { message = "User created successfully" });
}

}
