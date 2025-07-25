using Microsoft.AspNetCore.Mvc;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.ViewModel;

namespace TaskManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

			var respuesta = _service.ConectarUsuario(viewModel.Username, viewModel.Password);

            if (respuesta.EsValido)
            {
                // Guardamos el usuario en sesión
                HttpContext.Session.SetString("UserId", respuesta.UsuarioId.ToString()!);
                HttpContext.Session.SetString("Username", viewModel.Username);

                return RedirectToAction("Index", "TaskItem");
            }

            ViewBag.Error = respuesta.Mensaje;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerView)
        {
			if (!ModelState.IsValid)
			{
				// Retorna la vista con errores de validación automática
				return View(registerView);
			}
            var nuevoUser = new User(registerView.Username, registerView.Email, registerView.Password);
            var respuesta = _service.RegistrarUsuario(nuevoUser);

            if (respuesta.EsValido)
            {
                return RedirectToAction("Login");
            }
            ViewBag.Error = respuesta.Mensaje;
            return View();

        }
    }
}
