using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace Study2025.Server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class GoogleAuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public GoogleAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("google")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
        {
            try
            {
                // Validate Google ID Token
                var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { _configuration["Google:ClientId"] }
                });

                // Generate JWT
                var token = GenerateJwtToken(payload);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Invalid Google token", details = ex.Message });
            }
        }

        private string GenerateJwtToken(GoogleJsonWebSignature.Payload payload)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, payload.Subject),
            new Claim(JwtRegisteredClaimNames.Email, payload.Email),
            new Claim(JwtRegisteredClaimNames.Name, payload.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
public class GoogleLoginRequest
{
    public string IdToken { get; set; }
}