using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_CaPhee2_api.DTO;
using Web_CaPhee2_api.Models.Interface;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenRepository _tokenRepository;

    public AccountController(ITokenRepository tokenRepository, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _tokenRepository = tokenRepository;
        _roleManager = roleManager;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
    {
        if (registerRequestDTO == null || !ModelState.IsValid)
        {
            return BadRequest("Yêu cầu đăng ký không hợp lệ.");
        }

        var identityUser = new IdentityUser
        {
            UserName = registerRequestDTO.Username,
            Email = registerRequestDTO.Username
        };

        var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDTO.Password);
        if (identityResult.Succeeded)
        {
            if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
            {
                foreach (var role in registerRequestDTO.Roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));
                        if (!roleResult.Succeeded)
                        {
                            return BadRequest($"Tạo vai trò thất bại: {role}");
                        }
                    }
                }

                var rolesResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                if (!rolesResult.Succeeded)
                {
                    return BadRequest("Gán vai trò cho người dùng thất bại.");
                }
            }
            return Ok("Đăng ký thành công! Vui lòng đăng nhập.");
        }

        var errors = identityResult.Errors.Select(e => e.Description);
        return BadRequest(new { Errors = errors });
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
    {
        if (loginRequestDTO == null || !ModelState.IsValid)
        {
            return BadRequest("Yêu cầu đăng nhập không hợp lệ.");
        }

        var user = await _userManager.FindByEmailAsync(loginRequestDTO.Username);
        if (user != null)
        {
            var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if (checkPasswordResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());

                var response = new LoginResponseDTO
                {
                    JwtToken = jwtToken
                };

                return Ok(response);
            }
        }

        return Unauthorized("Tên người dùng hoặc mật khẩu không đúng.");
    }
}
