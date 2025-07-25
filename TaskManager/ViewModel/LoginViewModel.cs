using System.ComponentModel.DataAnnotations;

namespace TaskManager.ViewModel
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "El campo Username es obligatorio")]
		public string Username {  get; set; }

		[Required(ErrorMessage = "El campo Password es obligatorio")]
		[DataType(DataType.Password)]
		public string Password { get; set; }


	}
}
