using Microsoft.AspNetCore.Mvc;

namespace _03_Login.Controllers {
    public class LoginController : Controller {
        public IActionResult Login() {
            return View();
        }

        // Este [HttpPost] indica que solo entrará a este método si es que
        // la petición viene por POST
        // Para recibir la información que viene desde el FORM, tengo que poner name
        // a todos los elementos que enviarán su información Y aquí en el ActionResult
        // DEBO poner el mismo nombre de la variable que haya puesto en el name
        [HttpPost]
        public IActionResult Login(string username, string password) {

            if (username == "inacap" && password == "1234") {
                // De esta forma guardamos un dato en session
                HttpContext.Session.SetString("usuario", "inacap");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Datos ingresados incorrectos";
            return View();
        }
    }
}
