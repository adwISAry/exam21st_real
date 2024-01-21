using Exam21st.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam21st.Controllers
{
    public class AuthController : Controller
    {
        SignInManager<AppUser> _signInManager { get; set; }
        UserManager<AppUser> _userManager { get; set; }
        RoleManager<IdentityRole> _roleManager { get; set; }

        public IActionResult Index()
        {
            return View();
        }
    }
}
