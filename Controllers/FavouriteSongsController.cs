using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MFCommunity.Data;
using MFCommunity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MFCommunity.Controllers
{

    public class FavouriteSongsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public FavouriteSongsController(ApplicationDbContext context, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Method to save favourite user songs -----------------------------
        public async Task<IActionResult> saveFavSong (int SongID)
        {

            User user = await _userManager.GetUserAsync(User);
            Song song = await _context.Songs.FindAsync(SongID);
            
            FavouriteSong favouriteSong = new FavouriteSong
            {
                User = user,
                Song = song,
            };
            if (ModelState.IsValid)
            {
                _context.Add(favouriteSong);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // GET: FavouriteSongs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FavouriteSongs.Include(f => f.Song).ThenInclude(x => x.Album).ThenInclude(y => y.Artist).Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FavouriteSongs/Details/5
        //[Authorize(Roles = "Registered")] // Way to not execute code if the user is not in role
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favouriteSong = await _context.FavouriteSongs
                .Include(f => f.Song)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (favouriteSong == null)
            {
                return NotFound();
            }

            return View(favouriteSong);
        }

        // GET: FavouriteSongs/Create
        public IActionResult Create()
        {
            ViewData["SongID"] = new SelectList(_context.Songs, "ID", "SongTitle");
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: FavouriteSongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,SongID")] FavouriteSong favouriteSong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favouriteSong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SongID"] = new SelectList(_context.Songs, "ID", "SongTitle", favouriteSong.SongID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", favouriteSong.UserID);
            return View(favouriteSong);
        }

        // GET: FavouriteSongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favouriteSong = await _context.FavouriteSongs.FindAsync(id);
            if (favouriteSong == null)
            {
                return NotFound();
            }
            ViewData["SongID"] = new SelectList(_context.Songs, "ID", "SongTitle", favouriteSong.SongID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", favouriteSong.UserID);
            return View(favouriteSong);
        }

        // POST: FavouriteSongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,SongID")] FavouriteSong favouriteSong)
        {
            if (id != favouriteSong.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favouriteSong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavouriteSongExists(favouriteSong.ID))
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
            ViewData["SongID"] = new SelectList(_context.Songs, "ID", "SongTitle", favouriteSong.SongID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", favouriteSong.UserID);
            return View(favouriteSong);
        }

        // GET: FavouriteSongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favouriteSong = await _context.FavouriteSongs
                .Include(f => f.Song).ThenInclude(x => x.Album).ThenInclude(y => y.Artist)
                .Include(f => f.User)                
                .FirstOrDefaultAsync(m => m.ID == id);
            if (favouriteSong == null)
            {
                return NotFound();
            }

            return View(favouriteSong);
        }

        // POST: FavouriteSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favouriteSong = await _context.FavouriteSongs.FindAsync(id);
            _context.FavouriteSongs.Remove(favouriteSong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavouriteSongExists(int id)
        {
            return _context.FavouriteSongs.Any(e => e.ID == id);
        }
    }
}
