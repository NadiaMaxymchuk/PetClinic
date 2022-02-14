using BLL.Interfaces;
using BLL.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetClinic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Authenticate(model);
                if (user != null)
                {
                    await Authenticate(user);
                    return Ok(model);
                }
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Неправильний логін або пароль");
            }

            return Ok(model);
        }

        [HttpPost]
        [Route("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateUserViewModels model)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = _userService.GetByEmail(model.Email);
                if (userByEmail == null)
                {
                    var newUserId = _userService.Register(model);
                    var userById = _userService.GetById(newUserId);

                    await Authenticate(userById);

                    return Ok(model);
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Логін або пароль вже зайняті");
                }
            }

            return Ok(model);
        }

        private async Task Authenticate(UserViewModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String),
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("delete")]
        public void BlockUser(int Id)
        {
            _userService.BlockUserById(Id);
        }

        
    }
}
