using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using FunGuide.Data;
using FunGuide.Models;

namespace FunGuide.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Activities != null ? 
        //                  View(await _context.Activities.ToListAsync()) :
        //                  Problem("Entity set 'FunGuideContext.Activities'  is null.");
        //}

        


        public async Task<IActionResult> Index(string activitiesCategory, string searchString)
        {
            if (_context.Activities == null)
            {
                return Problem("Entity set 'FunGuideContext.Activities'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> categoryQuery = from m in _context.Activities
                                            orderby m.Category
                                            select m.Category;
            var activity = from m in _context.Activities
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                activity = activity.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(activitiesCategory))
            {
                activity = activity.Where(x => x.Category == activitiesCategory);
            }

            var activitiesCategoryVM = new ActivitiesCategoryViewModel
            {
                Category = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Activities = await activity.ToListAsync()
            };

            return View(activitiesCategoryVM);
        }


        //public async Task<IActionResult> ActivityList()

        //{

        //    return _context.Activities != null ?
        //                View(await _context.Activities.ToListAsync()) :
        //                Problem("Entity set 'FunGuideContext.Activities'  is null.");

        //}

        public async Task<IActionResult> ActivityList(string activitiesCategory, string searchString)
        {
            if (_context.Activities == null)
            {
                return Problem("Entity set 'FunGuideContext.Activities'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> categoryQuery = from m in _context.Activities
                                               orderby m.Category
                                               select m.Category;
            var activity = from m in _context.Activities
                           select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                activity = activity.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(activitiesCategory))
            {
                activity = activity.Where(x => x.Category == activitiesCategory);
            }


            var activitiesCategoryVM = new ActivitiesCategoryViewModel
            {
                Category = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Activities = await activity.ToListAsync()
            };

            return View(activitiesCategoryVM);
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activities == null)
            {
                return NotFound();
            }

            return View(activities);
        }
        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

         //   ViewData["Cart"].Add

            var activities = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activities == null)
            {
                return NotFound();
            }

            return View(activities);
        }

        

        //public async Task<IActionResult> CartDetails(int? id)
        //{
        //    Cart cart = new Cart()
        //    {
        //        activities = _context.Activities
        //        .FirstOrDefaultAsync(m => m.Id == id),
        //        Count = 1,
        //        Id = (int)id
        //    };
        //    return View(cart);
        //}

        public async Task<IActionResult> ActivityDetails(int? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activities == null)
            {
                return NotFound();
            }

            return View(activities);
        }

        

        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Name,Description,Category,Price")] Activities activities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activities);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities.FindAsync(id);
            if (activities == null)
            {
                return NotFound();
            }
            return View(activities);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,Description,Category,Price")] Activities activities)
        {
            if (id != activities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivitiesExists(activities.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(activities);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activities == null)
            {
                return NotFound();
            }

            return View(activities);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Activities == null)
            {
                return Problem("Entity set 'FunGuideContext.Activities'  is null.");
            }
            var activities = await _context.Activities.FindAsync(id);
            if (activities != null)
            {
                _context.Activities.Remove(activities);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivitiesExists(int id)
        {
          return (_context.Activities?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //public async Task<IActionResult> ActivityList()
        //{
        //    return _context.Activities != null ?
        //                View(await _context.Activities.ToListAsync()) :
        //                Problem("Entity set 'FunGuideContext.Activities'  is null.");
        //}




    }
}
