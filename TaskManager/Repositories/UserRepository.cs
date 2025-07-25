using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly TaskManagerDbContext _context;

        public UserRepository(TaskManagerDbContext context) {  _context = context; }


        public User? GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public User? GetByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(
                u => u.Username == username
                && 
                u.Password == password
            );
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
