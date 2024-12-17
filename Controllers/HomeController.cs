using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionConstructora.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
