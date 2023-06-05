using Microsoft.AspNetCore.Mvc;

namespace MVC_CookiesDemo.Controllers
{
    public class CookiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateCookies()
        {
            string key = "Intec";
            string value = "Hello from the cookies";
            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1)
            };
           HttpContext.Response.Cookies.Append(key, value);
            return View("Index");
        }

        public IActionResult ReadCookies()
        {
            string key = "Intec";
            string cookiesKey = Request.Cookies[key];  
            ViewBag.CookieKey = cookiesKey;
            return View();
        }

        public IActionResult RemoveCookies()
        {
            string key = "Intec";
            string value=string.Empty;
            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            HttpContext.Response.Cookies.Append(key, value,options);

            return View(nameof(Index));
        }
    }
}
