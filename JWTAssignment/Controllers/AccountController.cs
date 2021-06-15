using JWTAssignment.Helpers;
using JWTAssignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly TokenGenerator tokenGenerator;
        private readonly IConfiguration configuration;

        public AccountController(RoleManager<Role> roleManager, UserManager<User> userManager, IConfiguration configuration)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenGenerator = new TokenGenerator(userManager, configuration);
        }

        [HttpPost]
        [Route("Admin")]
        public async Task<IActionResult> CreateAdmin([FromBody]SignUpViewModel model)
        {
            try
            {
                var user = new User { UserName = model.UserName };
               var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    var roleResult = await userManager.AddToRoleAsync(user, "Admin");
                    if (roleResult.Succeeded) {
                        var token = await tokenGenerator.GenerateToken(user);
                        return Created("", new { user, token });
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> UserSignUp([FromBody] SignUpViewModel model)
        {
            try
            {
                var user = new User { UserName = model.UserName };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, "Normal");
                    if (roleResult.Succeeded)
                    {
                        var token = await tokenGenerator.GenerateToken(user);
                        return Created("", new { user, token });
                    }
                }
                return BadRequest(result.Errors);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
