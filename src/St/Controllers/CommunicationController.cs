using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using St.Data;
using St.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace St.Controllers
{
    [Authorize]
    public class CommunicationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommunicationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var chat = new Chat();
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            if (!_context.Chats.Any())
            {
                chat = new Chat()
                {
                     Author = user,
                     ChatId = "1111",
                      Date = new DateTime(),
                       Owner = user,
                        Text= "Hello World"
                };

                _context.Chats.Add(chat);
                _context.SaveChanges();
            }

            var list = new List<Chat>();
            list.Add(chat);
            return View(list);
        }
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}