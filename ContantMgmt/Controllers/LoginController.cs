using ContantMgmt.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContantMgmt.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model.Username != null && model.Username != "" && model.Password != null && model.Password != "")
            {
                bool bIsLoggedIn = false;
                bool bIsAdmin = false;
                string sUsername = "";
                if (model.Username == "admin" && model.Password == "123456")
                {
                    bIsLoggedIn = true;
                    bIsAdmin = true;
                    sUsername = "Admin";
                }
                if (model.Username == "guest" && model.Password == "123456")
                {
                    bIsLoggedIn = true;
                    sUsername = "Guest";
                }
                HttpContext.Session.SetString("bIsLoggedIn", bIsLoggedIn ? "1" : "0");
                HttpContext.Session.SetString("bIsAdmin", bIsAdmin ? "1" : "0");
                HttpContext.Session.SetString("sUsername", sUsername);

                // Store user data in AspNetUsers database table
                if (bIsLoggedIn)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.SetString("bIsLoggedIn", "0");
            HttpContext.Session.SetString("bIsAdmin", "0");

            return RedirectToAction("Index", "Home");
        }
    }
}
