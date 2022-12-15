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

namespace BestTimes.Controllers
{
    public class BestTimesController : Controller
    {
        readonly IBestTimesRepository repo;
        public BestTimesController(IBestTimesRepository repo)
        {
            this.repo = repo;
        }

        // GET: BestTimes
        public async Task<IActionResult> Index()
        {
              return View(await repo.GetBestTimesAsync());
        }


        // GET: BestTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BestTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Time")] PendingBestTimes bestTimes)
        {
            if (ModelState.IsValid)
            {
                await repo.SuggestBestTimeAsync(bestTimes);
                return RedirectToAction(nameof(Index));
            }
            return View(bestTimes);
        }
    }
}
