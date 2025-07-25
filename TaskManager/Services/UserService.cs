using TaskManager.Models;
using Microsoft.AspNetCore.Identity;
using TaskManager.Interfaces;

namespace TaskManager.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher<User> _passwordHasher;

		public UserService(IUserRepository repository, IPasswordHasher<User> passwordHasher) {  
            _repository = repository; 
            _passwordHasher = passwordHasher;
        }

        public bool RegistrarUsuario(User user)
        {
			var userInDb = _repository.GetByUsername(user.Username);

            if(userInDb == null)
            {
                user.Password = _passwordHasher.HashPassword(user, user.Password!);
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
			var result = _passwordHasher.VerifyHashedPassword(userInDb!, userInDb!.Password!, passwordEnView);
			if (result == PasswordVerificationResult.Failed)
            {
				response["mensaje"] = "La contraseña es incorrecta";
                return response;
				
			}

			response["todook"] = true;
			response["mensaje"] = "Accediste con éxito";
            return response;
		}

		public int RetornarIdDelUsuario(string username)
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
