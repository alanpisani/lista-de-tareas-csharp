using System.ComponentModel.DataAnnotations;

namespace TaskManager.ViewModel
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "El campo nombre de usuario es obligatorio")]
		[RegularExpression(@"^\S*$", ErrorMessage = "El campo no debe contener espacios.")]
		public string Username { get; set; }

		[Required(ErrorMessage = "El campo email es obligatorio")]
		[EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido")]
		public string Email { get; set; }

		[Required(ErrorMessage = "El campo contraseña es obligatorio")]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "La contraseña debe contener al menos 6 caracteres")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio"), DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
		public string RepeatPassword {get; set;}
	}
}
