using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Project_3._0.Filters;
using Project_3._0.Model.Domain;
using Project_3._0.Services;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class AdminController : Controller
    {
        private readonly IUserServices _userServices;
        public AdminController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet]
        [Route("{action}")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("{action}")]
        public IActionResult LogIn(string login, string pass)
        {
            if (login == string.Empty && pass == string.Empty)
            {
                ViewBag.Error = "Некорректный логин или пароль";
                return View("~/Views/Admin/Login.cshtml");
            }
            User res = _userServices.Authorize(login, pass);
            if (res == null)
            {
                ViewBag.Error = "Некорректный логин или пароль";
                return View("~/Views/Admin/Login.cshtml");
            }
            HttpContext.Session.SetString("UserFirstName", res.FirstName);
            HttpContext.Session.SetString("UserLastName", res.LastName);
            HttpContext.Session.SetInt32("UserPosition", res.Position);
            HttpContext.Session.SetInt32("UserId", res.IdUser);



            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        [AuthorizedOnly]
        [Route("{action}")]
        public IActionResult Dashboard()
        {
            //ViewBag.UserName = $"{HttpContext.Session.Keys.Contains("UserFirstName")}";
            //Console.WriteLine($"{context.Request.Cookies[".AspNetCore.Session"]}");

            Console.WriteLine($"{HttpContext.Request.Cookies[".AspNetCore.Session"].Contains("UserFirstName")}");
            Console.WriteLine($"{HttpContext.Session.GetString("UserFirstName")}");

            return View();
        }
    }
}
