using BlazorBattles.Server.Data;
using BlazorBattles.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister request)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Bananas = request.Bananas,
                DateOfBirth = request.DateOfBirth,
                IsConfirmed = request.IsConfirmed
            };

            var response = await _authRepository.Register(user, request.Password);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
