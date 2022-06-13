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
        public class BoardController : Controller
        {
            private AppDbContext _context;
            private IWebHostEnvironment _env;
            public BoardController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }
        public IActionResult Index()
        {
            List<Board> boards = _context.boards.ToList();
            return View(boards);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Board board)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExistName = _context.boards.Any(c => c.Description.ToLower() == board.Description.ToLower());
            if (isExistName)
            {
                ModelState.AddModelError("Description", "Eyni description`li board movcuddur.");
                return View();
            }

            Board newboard = new Board();
            newboard.Description = board.Description;
            newboard.Title = board.Title;
            newboard.Date = board.Date;
            await _context.boards.AddAsync(newboard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Board dbBoard = await _context.boards.FindAsync(id);
            if (dbBoard == null) return NotFound();
            _context.boards.Remove(dbBoard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
