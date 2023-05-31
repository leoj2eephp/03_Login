using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _03_Login.Filter {
    public class AccessFilter : IActionFilter {
        public void OnActionExecuted(ActionExecutedContext context) {
            // No hacemos nada
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            // context es el objeto que contiene el contexto desde donde está siendo llamado
            // nuestro filtro. Por ejemplo, a través de context podemos saber qué controller
            // y qué action fueron ejecutados para caer en el filter..

            // Aquí puedo preguntar primero si existe un usuario en SESSION
            var usuario = context.HttpContext.Session.GetString("usuario");
            // si no hay usuario en session hace el filtro
            if (usuario == null) {

                // con RouteData.Values podemos obtener el controller y action que fueron ejecutados
                // Aquí podemos preguntar si viene de Login/Login que no haga nada
                if (!context.RouteData.Values["controller"].Equals(("Login"))) {
                    // Si no viene de Login/Login, redireccionar a Login/Login
                    context.Result = new RedirectToActionResult("Login", "Login", null);
                }
            }
            // si encuentra un usuario en session, no hace nada.. lo deja pasar
        }
    }
}
