using Microsoft.AspNetCore.Mvc;

namespace CarritoCompras.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("LoginUsuario")]
        public IActionResult LoginUsuario(string correo, string contrasena)
        {
            string r = Models.Usuario.LoginUsuario(correo, contrasena);
            return Json(r);
        }
    }
}
