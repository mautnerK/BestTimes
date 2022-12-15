using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BestTimes.Data;
using BestTimes.Models;
using BestTimes.Repositories;
using System.Dynamic;

namespace BestTimes.Controllers
{
    public class PendingBestTimesController : Controller
    {
        readonly IAdminRepository repo;

        public PendingBestTimesController(IAdminRepository repo)
        {
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

        public async Task<IActionResult> SuccessPage()
        {
            ViewModel mymodel = new ViewModel();
            mymodel.BestTimes = await repo.GetBestTimesAsync();
            mymodel.PendingBestTimes = await repo.GetSuggestedTimesAsync();
            return View(mymodel);
        }

        public async Task<IActionResult> AcceptTime(int id)
        {
            PendingBestTimes pendingTime = await repo.GetSuggestedTimeByIdAsync(id);
            repo.AcceptSuggestedTimes(pendingTime);
            return RedirectToAction("SuccessPage", "PendingBestTimes");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptTime(int id, [Bind("Id,FirstName,LastName,Time")] PendingBestTimes pendingBestTimes)
        {
            repo.AcceptSuggestedTimes(pendingBestTimes);
            return RedirectToAction("SuccessPage", "PendingBestTimes");

        }

        public IActionResult Delete(int? id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var time = await repo.GetBestTimeByIdAsync(id);
            repo.RemoveTime(time);
            return RedirectToAction("SuccessPage", "PendingBestTimes");
        }

        public IActionResult DeleteSuggestedTime(int? id)
        {
            return View();
        }

        [HttpPost, ActionName("DeleteSuggestedTime")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSuggestedTimeConfirmed(int id)
        {
            var time = await repo.GetSuggestedTimeByIdAsync(id);
            repo.RemoveSuggestedTime(time);
            return RedirectToAction("SuccessPage", "PendingBestTimes");
        }
    }
}
