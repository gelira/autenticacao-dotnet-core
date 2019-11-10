using Autenticacao.Entities;

namespace Autenticacao.Services
{
    public interface IUserService
    {
        User Autenticar(string username, string password);
        User GetUserById(int id);
    }
}
