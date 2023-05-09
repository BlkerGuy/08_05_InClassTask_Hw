using _08_05_InClassTask_Hw.Models;
using Microsoft.AspNetCore.Mvc;

namespace _08_05_InClassTask_Hw.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Brand> _brands;

        public HomeController()
        {
            _brands = new List<Brand>
            {
                new Brand{Id=1,Name="Bmw"},
                new Brand{Id=2,Name="Mercedes"}
            };
        }
        public IActionResult Index()
        {
            return View(_brands);
        }
      

    }
}
