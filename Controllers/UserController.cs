using AutoMapper;
using downstreem.Dtos;
using downstreem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace downstreem.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserController(SignInManager<User> signInManager, 
            UserManager<User> userManager,
            IMapper mapper,
            ILogger<UserController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Email);
                    /*var userRole = await _signInManager.UserManager.GetRolesAsync(user);
                    if (userRole.Count > 0 && userRole[0].Equals("Administrator"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "" });
                    }*/
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Email or Password incorrect");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Redirect("/");
            }
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(UserSignUpDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _mapper.Map<User>(model);
            user.UserName = model.Email;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Add role
                _userManager.AddToRoleAsync(user, "User").Wait();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                ModelState.AddModelError("", "Error occurred");
                return View(model);
            }
        }
    }
}
