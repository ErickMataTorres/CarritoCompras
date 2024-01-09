using Microsoft.AspNetCore.Mvc;

namespace CarritoCompras.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Carts")]
        public IActionResult Carts()
        {
            var r = Models.Cart.Carts();
            return Json(r);
        }

    }
}
