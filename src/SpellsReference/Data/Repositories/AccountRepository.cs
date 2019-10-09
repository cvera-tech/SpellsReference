using System;
using System.Collections.Generic;
using SpellsReference.Models;
using System.Linq;

namespace SpellsReference.Data.Repositories
{
    using BCrypt.Net;

    public class AccountRepository : IAccountRepository
    {
        private IContext context;

        public AccountRepository(IContext context)
        {
            this.context = context;
        }

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
            var user = Get(username);
            if (user == null)
            {
                return false;
            }
            else
            {
                return BCrypt.Verify(password, user.HashedPassword);
            }
        }

        public User Get(string username)
        {
            var user = context.Users
                .SingleOrDefault(u => u.Email == username);
            return user;
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