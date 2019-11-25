using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MFCommunity.Models;
using MFCommunity.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using MFCommunity.Data;

namespace MFCommunity.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Random random = new Random();
            
            HomeVM homeVM = new HomeVM
            {
                Albums = _context.Albums.Include(a => a.Artist).ToList(), // Adding the artist name from Artist DB --------------------------
                Songs = _context.Songs.ToList(),
                
                // Creating three random numbers to the Albums carousel -------------------------------------------
                carousel1 = random.Next(0, 3),
                carousel2 = random.Next(3, 6),
                carousel3 = random.Next(6, 9),
            };

            return View(homeVM);
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
