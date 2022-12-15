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
using BestTimes.Service;

namespace BestTimes.Controllers
{
    public class PendingBestTimesController : Controller
    {
        readonly IAdminService service;

        public PendingBestTimesController(IAdminService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> SuccessPage()
        {
            ViewModel mymodel = new ViewModel();
            mymodel.BestTimes = await service.GetBestTimesAsync();
            mymodel.PendingBestTimes = await service.GetSuggestedTimesAsync();
            return View(mymodel);
        }

        public async Task<IActionResult> AcceptTime(int id)
        {
            PendingBestTimes pendingTime = await service.GetSuggestedTimeByIdAsync(id);
            service.AcceptSuggestedTimes(pendingTime);
            return RedirectToAction("SuccessPage", "PendingBestTimes");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult AcceptTime(int id, [Bind("Id,FirstName,LastName,Time")] PendingBestTimes pendingBestTimes)
        {
            service.AcceptSuggestedTimes(pendingBestTimes);
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
            var time = await service.GetBestTimeByIdAsync(id);
            service.RemoveTime(time);
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
            var time = await service.GetSuggestedTimeByIdAsync(id);
            service.RemoveSuggestedTime(time);
            return RedirectToAction("SuccessPage", "PendingBestTimes");
        }
    }
}
