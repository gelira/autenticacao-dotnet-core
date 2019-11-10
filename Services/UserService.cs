using System.Linq;
using Autenticacao.Entities;

namespace Autenticacao.Services
{
    public class UserService : IUserService
    {
        private DatabaseContext context;

        public UserService(DatabaseContext context)
        {
            this.context = context;
        }

        public User Autenticar(string username, string password)
        {
            return context.Users.SingleOrDefault(
                u => u.Username.Equals(username) && u.Password.Equals(password));
        }

        public User GetUserById(int id)
        {
            return context.Users.SingleOrDefault(u => u.Id == id);
        }
    }
}
