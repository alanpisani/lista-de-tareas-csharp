using Microsoft.AspNetCore.Identity;
using TaskManager.Models;

namespace TaskManager.Interfaces
{
	public interface IUserService
	{
		public bool RegistrarUsuario(User user);

		public Dictionary<string, object> ConectarUsuario(String username, String password);

		public int RetornarIdDelUsuario(string username);

		public User? RetornarUsuarioPorUsername(String username);
	}
}
