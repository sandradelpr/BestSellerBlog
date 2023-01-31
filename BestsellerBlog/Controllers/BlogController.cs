using Microsoft.AspNetCore.Mvc;

namespace BestsellerBlog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
