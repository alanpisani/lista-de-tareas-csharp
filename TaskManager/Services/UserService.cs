using TaskManager.Models;
using Microsoft.AspNetCore.Identity;
using TaskManager.Interfaces;
using TaskManager.Validators;

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

        public UserValidator RegistrarUsuario(User user)
        {
            UserValidator validator = new();
			var userInDb = _repository.GetByUsername(user.Username);

            validator.ValidacionRegister(
                usuarioEnBD: userInDb!
                );

            if (validator.EsValido) {
				_repository.Add(user);
			}
            return validator;
        }

        public UserValidator ConectarUsuario(String username, String password)
        {
			UserValidator validator = new();
            var userInDb = _repository.GetByUsername(username);
            validator.ValidacionLogin(
                usuarioEnBD: userInDb!, 
                passwordEnView: password, 
                passwordHasher: _passwordHasher
                );

            return validator;
        }

    }
}
