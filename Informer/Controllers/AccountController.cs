using Informer.BLL.Contract.Models;
using Informer.Infrastructure;
using Informer.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Informer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private IJwtAuthManager _jwtAuthManager;

        public AccountController(IConfiguration config, IJwtAuthManager jwtAuthManager)
        {
            _config = config;
            _jwtAuthManager = jwtAuthManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AccountDTO account)
        {
            //your logic for login process
            //If login usrename and password are correct then proceed to generate token

            var claims = new[]
            {
            new Claim(ClaimTypes.Name,account.UserName)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(account.UserName, claims, DateTime.Now);

            return Ok(new LoginResult
            {
                UserName = account.UserName,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [HttpPost("logout")]
        public ActionResult Logout()
        {
            var userName = User.Identity?.Name!;
            _jwtAuthManager.RemoveRefreshTokenByUserName(userName);
            return Ok();
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var userName = User.Identity?.Name!;

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken ?? string.Empty, DateTime.Now);
                return Ok(new LoginResult
                {
                    UserName = userName,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
            }
        }
    }
}