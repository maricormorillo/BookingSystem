using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunGuide.Areas.Data;
using FunGuide.Data;
using FunGuide.Models;

namespace FunGuide.Controllers
{
    public class UserActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserActivitiesController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: UserActivities
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.UserActivities.Include(u => u.User).Include(x => x.Activities);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(_context.UserActivities.Include(u => u.Activities).Include(u => u.User));
            }
            else
            {
                return View(_context.UserActivities.Include(x => x.Activities).Include(u => u.User).Where(x => x.UserId == _userManager.GetUserId(User)));
            }
        }

        // GET: UserActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserActivities == null)
            {
                return NotFound();
            }

            var userActivities = await _context.UserActivities
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (userActivities == null)
            {
                return NotFound();
            }

            return View(userActivities);
        }
        // POST: UserActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> AssignUserActivity(int? ActivityId)
        {

            var userId = _userManager.GetUserId(User);
            //if (ModelState.IsValid)
            //{
            //    _context.Add(userActivities);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            UserActivities userActivities = new UserActivities();
            userActivities.UserId = userId;
            userActivities.ActivityId = ActivityId;
            _context.UserActivities.Add(userActivities);
            await _context.SaveChangesAsync(); 

            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userActivities.UserId);
            return RedirectToAction(nameof(Index));
        }

        // GET: UserActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserActivities == null)
            {
                return NotFound();
            }

            var userActivities = await _context.UserActivities.FindAsync(id);
            if (userActivities == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userActivities.UserId);
            return View(userActivities);
        }

        // POST: UserActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,ActivityId")] UserActivities userActivities)
        {
            if (id != userActivities.ActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userActivities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserActivitiesExists(userActivities.ActivityId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userActivities.UserId);
            return View(userActivities);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (_context.UserActivities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserActivities'  is null.");
            }
            var userActivities = await _context.UserActivities.Where(x => x.UserId == userId && x.ActivityId == id).FirstOrDefaultAsync();
            if (userActivities != null)
            {
                _context.UserActivities.Remove(userActivities);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserActivitiesExists(int? id)
        {
          return (_context.UserActivities?.Any(e => e.ActivityId == id)).GetValueOrDefault();
        }
    }
}
