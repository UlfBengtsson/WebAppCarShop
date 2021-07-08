using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAppCarShop.Models.Data;

namespace WebAppCarShop.Controllers
{
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        public JwtController(
            SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(JwtLogin jwtLogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(jwtLogin.UserName, jwtLogin.Password, false, true);

                if (!result.Succeeded)
                {
                    return Unauthorized();
                }
                IdentityUser user = await _userManager.GetUserAsync(User);
                //ToDo token gen
                JwtSecurityToken jwtTokenData = await GenerateJwtToken(user);

                JwtToken jwtToken = new JwtToken() { Token = new JwtSecurityTokenHandler().WriteToken(jwtTokenData) };

                return Ok(jwtToken);
            }
            return BadRequest(ModelState);
        }

        private async Task<JwtSecurityToken> GenerateJwtToken(IdentityUser user)
        {
            List<Claim> claims = User.Claims.ToList();

            int expiraionDays = _configuration.GetValue<int>("JWTConfiguration:TokenExpirationDays");
            byte[] signingKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigningKey"));
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                claims: User.Claims,
                expires: DateTime.UtcNow.AddDays(expiraionDays),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256)
                );

            return jwtSecurityToken;
        }
    }
}
