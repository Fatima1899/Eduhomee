using Eduhomee.DAL;
using Eduhomee.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhomee.Areas.AdminF.Controllers
{
   
        [Area("AdminF")]
        public class EventBoardController : Controller
        {
            private AppDbContext _context;
            private IWebHostEnvironment _env;
            public EventBoardController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }
            public IActionResult Index()
            {
                List<EventBoard> eventBoards = _context.eventBoards.ToList();
                return View(eventBoards);
            }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(EventBoard eventBoard)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                bool isExistName = _context.eventBoards.Any(c => c.Description.ToLower() == eventBoard.Description.ToLower());
                if (isExistName)
                {
                    ModelState.AddModelError("Description", "Eyni description`li board movcuddur.");
                    return View();
                }

                EventBoard neweventBoard = new EventBoard();
                neweventBoard.Description = eventBoard.Description;
                neweventBoard.Title = eventBoard.Title;
                await _context.eventBoards.AddAsync(neweventBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }

            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null) return NotFound();
                EventBoard dbEventBoard = await _context.eventBoards.FindAsync(id);
                if (dbEventBoard == null) return NotFound();
                _context.eventBoards.Remove(dbEventBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


        }
    
}
