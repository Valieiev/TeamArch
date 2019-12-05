﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Shared;

namespace Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private static readonly UserModel LoggedOutUser = new UserModel {IsAuthenticated = false};

        private readonly UserManager<IdentityUser> _userManager;

        public AccountsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            var newUser = new IdentityUser {UserName = model.Email, Email = model.Email};
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Accepted(new RegisterResult {Successful = false, Errors = errors});
            }

            return Ok(new RegisterResult {Successful = true});
        }

        [HttpGet("user")]
        public IActionResult GetUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userModel = new UserModel
                {
                    Email = User.Identity.Name,
                    IsAuthenticated = true
                };

                return Ok(userModel);
            }

            return Ok(LoggedOutUser);
        }
    }
}