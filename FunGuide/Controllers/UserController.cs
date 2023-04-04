using FunGuide.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using FunGuide.Areas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FunGuide.Data;

namespace FunGuide.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        //private readonly ILogger<UserController> _logger;
        //private UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        //public UserController(ILogger<UserController> context, UserManager<AppUser> userManager)
        public UserController(ApplicationDbContext context, UserManager<AppUser> userManager)

        {
            _context= context;
            _userManager = userManager;
            
        }

        

        public IActionResult Index()
        {
            //Console.WriteLine("------");
            return View(_userManager.Users.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }         // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Email, UserName,Id")] AppUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
            var userExists = _context.Users.FirstOrDefault(x => x.Id == id); 

            if (userExists == null)
            {
                return NotFound();
            }             //Update data
            userExists.FirstName = user.FirstName;
            userExists.LastName = user.LastName;
            userExists.Email = user.Email;
            //userExists.UserName = user.UserName; 
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Users.Update(userExists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(userExists);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'FunGuideContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id); if (user != null)
            {
                //if (DeleteAllUserList(id))
                //{
                    _context.Users.Remove(user);
                //}
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeleteAllUserList(string id)
        {
            throw new NotImplementedException();
        }

        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //private bool DeleteAllUserList(string id)
        //{
        //    var tables = _context.UserList.Where(x => x.id == id).ToList();
        //    foreach (var item in tables)
        //    {
        //        try
        //        {
        //            bool v = _context.UserList.Remove(item);
        //        }
        //        catch (ArgumentException e)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //public List<UserList>? userList { get; set; }
    }
}