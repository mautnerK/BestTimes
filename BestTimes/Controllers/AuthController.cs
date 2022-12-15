using BestTimes.Data;
using BestTimes.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestTimes.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            AdminLoginInfo adminLogin = new AdminLoginInfo();
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminLoginInfo adminLogin)
        {
            BestTimesContext context = new BestTimesContext();
            var status = context.AdminLoginInfo.Where(m => m.Username == adminLogin.Username && m.Password == adminLogin.Password).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("SuccessPage", "PendingBestTimes");
            }
            return View();
        }

    }
}
