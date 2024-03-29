﻿using Api.Models;
using Application.Core;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public IdentityController(UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var userExists = await _userManager.FindByNameAsync(registerModel.UserName);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Result<bool>.Failure("User already exists"));
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerModel.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = registerModel.Email,
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Result<bool>.Failure("User creation failed", result.Errors.Select(x => x.Description)));
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            await _userManager.AddToRoleAsync(user, UserRoles.User);


            return Ok(Result<bool>.Success(true));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterRO(RegisterModel registerModel)
        {
            var userExists = await _userManager.FindByNameAsync(registerModel.UserName);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Result<bool>.Failure("User already exists"));
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerModel.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = registerModel.Email,
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                IEnumerable<string> a = result.Errors.Select(x => x.Description);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Result<bool>.Failure("User creation failed", result.Errors.Select(x => x.Description)));
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.UserRO))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.UserRO));

            await _userManager.AddToRoleAsync(user, UserRoles.UserRO);


            return Ok(Result<bool>.Success(true));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if (user is not null && isPasswordCorrect)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var userRoles = await _userManager.GetRolesAsync(user);

                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                        expires: DateTime.Now.AddHours(2),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new 
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }
    }
}
