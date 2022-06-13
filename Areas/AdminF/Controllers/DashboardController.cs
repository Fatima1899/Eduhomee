using Microsoft.AspNetCore.Mvc;

namespace Eduhomee.Areas.AdminF.Controllers
{
    public class DashboardController : Controller
    {
        [Area ("AdminF")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
