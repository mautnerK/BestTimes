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

        // GET: PendingBestTimes
        [HttpGet]
        public async Task<IActionResult> Index()
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
        // GET: PendingBestTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PendingBestTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Time")] PendingBestTimes pendingBestTimes)
        {
           
            return View(pendingBestTimes);
        }

        // GET: PendingBestTimes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            PendingBestTimes pendingTime = await repo.GetSuggestedTimeById(id);
            repo.AcceptSuggestedTimes(pendingTime);
            return RedirectToAction("SuccessPage", "PendingBestTimes");
           
        }

        // POST: PendingBestTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Time")] PendingBestTimes pendingBestTimes)
        {
            repo.AcceptSuggestedTimes(pendingBestTimes);
            return RedirectToAction("SuccessPage", "PendingBestTimes");

        }

        // GET: PendingBestTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           
            return View();
        }

        // POST: PendingBestTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          
            return  RedirectToAction(nameof(Index));
        }

       
    }
}
