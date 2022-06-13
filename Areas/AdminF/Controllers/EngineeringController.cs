using Eduhomee.DAL;
using Eduhomee.Extentions;
using Eduhomee.Helpers;
using Eduhomee.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhomee.Areas.AdminF.Controllers
{
    
    
        [Area("AdminF")]
        public class EngineeringController : Controller
        {
            private AppDbContext _context;
            private IWebHostEnvironment _env;
            public EngineeringController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }
            public IActionResult Index()
            {
                List<Engineering> engineerings = _context.engineerings.ToList();
                return View(engineerings);
            }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Engineering engineering)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                bool isExistName = _context.engineerings.Any(c => c.Description.ToLower() == engineering.Description.ToLower());
                if (isExistName)
                {
                    ModelState.AddModelError("Description", "Eyni description`li card movcuddur.");
                    return View();
                }


                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }
                if (!engineering.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "accept only image");
                    return View();
                }
                if (engineering.Photo.ImageSize(10000))
                {
                    ModelState.AddModelError("Photo", "1mg yuxari ola bilmez");
                    return View();
                }
                string fileName = await engineering.Photo.SaveImage(_env, "img");




                Engineering newengineering = new Engineering();
                newengineering.Description = newengineering.Description;
                newengineering.Title = newengineering.Title;
                newengineering.ImageUrl = fileName;
                await _context.engineerings.AddAsync(newengineering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null) return NotFound();
                Course dbCourse = await _context.courses.FindAsync(id);
                if (dbCourse == null) return NotFound();
                Helper.DeleteFile(_env, "img", dbCourse.ImageUrl);
                _context.courses.Remove(dbCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }

