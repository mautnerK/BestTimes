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
using BestTimes.Service;

namespace BestTimes.Controllers
{
    public class BestTimesController : Controller
    {
        readonly IBestTimesService service;
        public BestTimesController(IBestTimesService service)
        {
            this.service = service;
        }

        // GET: BestTimes
        public async Task<IActionResult> Index()
        {
              return View(await service.GetBestTimesAsync());
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
                await service.SuggestBestTimeAsync(bestTimes);
                return RedirectToAction(nameof(Index));
            }
            return View(bestTimes);
        }
    }
}
