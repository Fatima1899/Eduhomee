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
        public class CourseController : Controller
        {
            private AppDbContext _context;
            private IWebHostEnvironment _env;
            public CourseController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }
            public IActionResult Index()
            {
                List<Course> courses = _context.courses.ToList();
                return View(courses);
            }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExistName = _context.courses.Any(c => c.Description.ToLower() == course.Description.ToLower());
            if (isExistName)
            {
                ModelState.AddModelError("Description", "Eyni description`li card movcuddur.");
                return View();
            }

            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!course.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "accept only image");
                return View();
            }
            if (course.Photo.ImageSize(10000))
            {
                ModelState.AddModelError("Photo", "1mg yuxari ola bilmez");
                return View();
            }
            string fileName = await course.Photo.SaveImage(_env, "img");
            

            Course newcourse = new Course();
            newcourse.Description = course.Description;
            newcourse.Count = course.Count;
            newcourse.Date = course.Date;
            newcourse.ImageUrl = fileName;
            await _context.courses.AddAsync(newcourse);
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
