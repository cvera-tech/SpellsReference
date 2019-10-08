using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpellsReference.Models;

namespace SpellsReference.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public int? Add(User entity)
        {
            throw new NotImplementedException();
        }

        public int? Add(User entity, string password)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public User Get(string username)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> List()
        {
            throw new NotImplementedException();
        }
    }
}