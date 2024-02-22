using LoginApp.IdenttiyClasses;
using LoginApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<MyUser> userManager;
        private readonly SignInManager<MyUser> signInManager;

        public UserController(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new MyUser()
            {
                Fullname = model.Fullname,
                Email = model.Email,
                Contact = model.Contact,
                Address = model.Address,
                UserName = model.Email,
                PasswordHash = model.Password
            };
            var result = await userManager.CreateAsync(user, user.PasswordHash!);
            if(result.Succeeded)
            {
                return Ok("Registration was successful!");
            } 
            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var signInResult = await signInManager.PasswordSignInAsync(
                userName: email,
                password: password,
                isPersistent: false,
                lockoutOnFailure: false
                );
            if(signInResult.Succeeded)
            {
                return Ok("You are signed in!");
            }
            else
            {
                return BadRequest(signInResult);
            }
           
        }
    }
}
