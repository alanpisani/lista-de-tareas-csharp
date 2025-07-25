using Microsoft.AspNetCore.Identity;
using TaskManager.Models;
using TaskManager.Validators;

namespace TaskManager.Interfaces
{
	public interface IUserService
	{
		public UserValidator RegistrarUsuario(User user);

		public UserValidator ConectarUsuario(String username, String password);

	}
}
