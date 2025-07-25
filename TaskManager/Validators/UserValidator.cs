using Microsoft.AspNetCore.Identity;
using TaskManager.Models;

namespace TaskManager.Validators
{
	public class UserValidator
	{
		public bool EsValido { get; set; }
		public string Mensaje { get; set; }
		public int? UsuarioId { get; set; }	

		public UserValidator()
		{
			EsValido = false;
			Mensaje = string.Empty;
		}

		public void ValidacionLogin(User usuarioEnBD, string passwordEnView, IPasswordHasher<User> passwordHasher)
		{
			if (usuarioEnBD == null)
			{
				Mensaje = "El usuario no existe";
				return;
			}
			var result = passwordHasher.VerifyHashedPassword(usuarioEnBD!, usuarioEnBD!.Password!, passwordEnView);
			if (result == PasswordVerificationResult.Failed)
			{
				Mensaje = "La contraseña es incorrecta";
				return;
			}
			EsValido = true;
			UsuarioId = usuarioEnBD.Id;
		}

		public void ValidacionRegister(User usuarioEnBD)
		{
			if (usuarioEnBD != null) {
				Mensaje = "El nombre de usuario ya existe. Elegí otro.";
				return;
			}
			EsValido = true;
			Mensaje = "El usuario ha sido registrado con éxito";
		}
	}
}
