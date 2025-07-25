using TaskManager.Models;

namespace TaskManager.Interfaces
{
	public interface IUserRepository
	{
		User? GetByUsername(string username);
		User? GetByUsernameAndPassword(string username, string password);
		void Add(User user);
	}
}
