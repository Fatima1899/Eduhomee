using Eduhomee.DAL;
using Eduhomee.Views_Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eduhomee.Controllers
{
    public class HomeController : Controller
    {
           private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.sliders = _context.sliders.ToList();
            homeVM.boards = _context.boards.ToList();
            homeVM.eventBoards = _context.eventBoards.ToList();
            homeVM.engineerings = _context.engineerings.ToList();
            homeVM.courses = _context.courses.ToList();
            homeVM.events = _context.events.ToList();
            return View(homeVM);
        }
    }
}
