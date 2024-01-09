using Microsoft.AspNetCore.Mvc;

namespace CarritoCompras.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin(Models.User c)
        {
            var r = c.UserLogin();
            return Json(r);
        }
    }
}
