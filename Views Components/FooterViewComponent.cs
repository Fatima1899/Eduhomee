using Eduhomee.DAL;
using Eduhomee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhomee.Views_Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _contex;
        public FooterViewComponent(AppDbContext contex)
        {
            _contex = contex;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Bio model = _contex.bios.FirstOrDefault();
            return View(await Task.FromResult(model));
        }
    }
}
