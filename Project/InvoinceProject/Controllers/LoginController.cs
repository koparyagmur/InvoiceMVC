using InvoinceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoinceProject.Controllers
{
    public class LoginController : Controller
    {
        LoginDAL objLogin = new LoginDAL();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Check()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(string UserName, string Password)
        {
            if (UserName == null && Password == null)
            {
                return NotFound();
            }
            Login objUser = objLogin.GetLoginData(UserName, Password);

            if (objUser.UserName == null || objUser.Password == null)
            {
                TempData["error"] = "Wrong username or password";
                return RedirectToAction("Index", "Login");
            }
            else
            {
                HttpContext.Session.SetString("Username", objUser.UserName);
                TempData["User"] = HttpContext.Session.GetString("Username");
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
