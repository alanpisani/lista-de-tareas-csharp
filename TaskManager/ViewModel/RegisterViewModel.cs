using System.ComponentModel.DataAnnotations;

namespace TaskManager.ViewModel
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "El campo Username es obligatorio")]
		public string Username { get; set; }

		[Required(ErrorMessage = "El campo Email es obligatorio")]
		[EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido")]
		public string Email { get; set; }

		[Required(ErrorMessage = "El campo Password es obligatorio")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "El campo RepeatPassword es obligatorio"), DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
		public string RepeatPassword {get; set;}
	}
}
