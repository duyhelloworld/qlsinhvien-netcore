using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using qlsinhvien.Context;
using qlsinhvien.SecurityConfig.Model;

namespace qlsinhvien.SecurityConfig.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly AppSetting _appSetting;
    private readonly ApplicationContext _context;

    // public UserController(ApplicationContext context, IOptionsMonitor<AppSetting> appSetting)
    // {
    //     _context = context;
    //     _appSetting = appSetting.CurrentValue;
    // }

    // [HttpGet]
    // private string GetKey() {
    //     Console.WriteLine("Key = " + _appSetting.SecretKey);
    //     return _appSetting.SecretKey;
    // }


    public UserController(ApplicationContext context, IConfiguration configuration)
    {
        _context = context;
        _appSetting = new AppSetting() {SecretKey = configuration.GetSection("AppSetting:SecretKey").Value!};
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel loginModel) {
        if (loginModel.Username == "admin" && loginModel.Password == "admin")
        {
            return Ok(new ResponseLoginModel() {
                IsSuccess = true,
                Message = "Login OK",
                Data = GetJwt(loginModel)
            });
        }
        return BadRequest(new ResponseLoginModel() {
            IsSuccess = false,
            Message = "Invalid username / password"
        });
    }

    private string GetJwt(LoginModel loginModel) {
        var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);
        var tokenDescription = new SecurityTokenDescriptor() {
            Issuer = "duypham",
            Subject = new ClaimsIdentity(
                new Claim[] {
                    new Claim(ClaimTypes.Name, loginModel.Username.ToUpper()),
                    new Claim("Username", loginModel.Username, ClaimValueTypes.String),
                    new Claim(ClaimTypes.Role, "admin", ClaimValueTypes.String),
                }
            ),
            Expires = DateTime.UtcNow.AddMinutes(5),
            // ~ giờ UTC (+7) hiện tại + 1m
            // IssuedAt = DateTime.UtcNow,
            // NotBefore = DateTime.UtcNow.AddSeconds(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(secretKeyBytes),
                SecurityAlgorithms.HmacSha512),
            TokenType = "JWT"
        };

        // tạo token
        var jwtHandler = new JwtSecurityTokenHandler();
        var token = jwtHandler.CreateToken(tokenDescription);
        return jwtHandler.WriteToken(token);
    }

    [Authorize]
    [HttpGet("all")]
    public IEnumerable<LoginModel> TaskToSecure() {
        var loginModel = new HashSet<LoginModel>() {
            new LoginModel() { Username = "user1", Password = "user1"},
            new LoginModel() { Username = "user2", Password = "user2"},
            new LoginModel() { Username = "user3", Password = "user3"},
        };
        return loginModel;
    }
}