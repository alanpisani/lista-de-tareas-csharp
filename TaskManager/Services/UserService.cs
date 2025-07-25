using TaskManager.Repositories;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository) {  _repository = repository; }

        public bool RegistrarUsuario(User user)
        {
            var userInDb = _repository.GetByUsername(user.Username);

            if(userInDb == null)
            {
                _repository.Add(user);
                return true;
            }
            return false;
        }

        public Dictionary<string, object> ConectarUsuario(String username, String password)
        {
            var userInDb = _repository.GetByUsername(username);
            var response = _validacionLogin(userInDb!, password);

            return response;
        }

		private Dictionary<string, object> _validacionLogin(User userInDb, string passwordEnView)
		{
			Dictionary<string, object> response = new();
			response["todook"] = false;

			if (userInDb == null)
			{
				response["mensaje"] = "El usuario no existe";
				return response;
			}
			if(passwordEnView != userInDb.Password)
            {
				response["mensaje"] = "La contraseña es incorrecta";
				return response;
			}
			response["todook"] = true;
			response["mensaje"] = "Accediste con éxito";
            return response;
		}

		public int retornarIdDelUsuario(string username)
        {
            var userInDb = _repository.GetByUsername(username);

            return userInDb!.Id;
        }

        public User? RetornarUsuarioPorUsername(String username)
        {
            return _repository.GetByUsername(username);
        }
    }
}
