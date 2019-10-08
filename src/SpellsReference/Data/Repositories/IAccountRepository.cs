using SpellsReference.Models;

namespace SpellsReference.Data.Repositories
{
    public interface IAccountRepository : IRepository<User>
    {
        int? Add(User entity, string password);
        bool Authenticate(string username, string password);
        User Get(string username);
    }
}
