using BestTimes.Data;
using BestTimes.Models;
using BestTimes.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace BestTimes.Controllers
{
    public class HomeController : Controller
    {
        readonly IAdminRepository repo;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IAdminRepository repo)
        {
            _logger = logger;
            this.repo = repo;
        }
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
            if(status == null) {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("SuccessPage", "PendingBestTimes");
            }
            return View();
        }
        public async Task<IActionResult> SuccessPage()
        {
            ViewModel mymodel = new ViewModel();
            mymodel.BestTimes = await repo.GetBestTimesAsync();
            mymodel.PendingBestTimes = await repo.GetSuggestedTimesAsync();
            return View(mymodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Time")] PendingBestTimes pendingBestTimes)
        {
            repo.AcceptSuggestedTimes(pendingBestTimes);
            return RedirectToAction("SuccessPage", "PendingBestTimes");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}