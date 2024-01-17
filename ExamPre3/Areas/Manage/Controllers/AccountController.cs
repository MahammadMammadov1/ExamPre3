using ExamPre3.Areas.Manage.ViewModel;
using ExamPre3.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamPre3.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel vm)
        {

            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(vm.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "invalid username or password");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, true, true);


            if (!result.Succeeded)
            {
                
                    ModelState.AddModelError("", "invalid username or password");
                    return View();
                
            }
            return RedirectToAction("Index","dashboard");
        }

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser user = new AppUser
            { 
                FullName = "Mehemmed",
                UserName = "SuperAdmin"
            };

            await _userManager.CreateAsync(user,"Admin123@");
            await _userManager.AddToRoleAsync(user, "SuperAdmin");

            return Ok("Yarandi");

        }


        public async Task<IActionResult> Role()
        {
            IdentityRole role = new IdentityRole("SuperAdmin");
            IdentityRole role1 = new IdentityRole("Admin");
            IdentityRole role2 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role);
            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);

            return Ok("Yarandi");

        }
    }
}
