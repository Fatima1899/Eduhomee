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
        public class BioController : Controller
        {
            private AppDbContext _context;
            private IWebHostEnvironment _env;
            public BioController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }
            public IActionResult Index()
            {
                List<Bio> bios = _context.bios.ToList();
                return View(bios);
            }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Bio bio)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                Bio newbio = new Bio();
                newbio.Facebook = bio.Facebook;
                newbio.Logo = bio.Logo;
                newbio.Number = bio.Number;
                newbio.Pinterest = bio.Pinterest;
                newbio.Vcontact = bio.Vcontact;
                newbio.Twitter = bio.Twitter;
                await _context.bios.AddAsync(newbio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }

            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null) return NotFound();
                Bio dbBio = await _context.bios.FindAsync(id);
                if (dbBio == null) return NotFound();
                _context.bios.Remove(dbBio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


        }
    
}
