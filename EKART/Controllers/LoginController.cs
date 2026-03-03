using EKART.Models;
using EKART.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EKART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtRepository _jwtRepository;
        public LoginController(IJwtRepository jwtRepository)
        {
            _jwtRepository = jwtRepository;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var result= await _jwtRepository.Authenticate(loginRequest);
            if (result is null) return Unauthorized();
            return Ok(result);
        }
    }
}
