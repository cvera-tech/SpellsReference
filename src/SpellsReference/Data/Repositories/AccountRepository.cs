using System;
using System.Collections.Generic;
using SpellsReference.Models;
using System.Linq;

namespace SpellsReference.Data.Repositories
{
    using BCrypt.Net;

    public class AccountRepository : IAccountRepository
    {
        private IContext _context;

        public AccountRepository(IContext context)
        {
            _context = context;
        }

        public int? Add(User entity)
        {
            throw new NotImplementedException();
        }

        public int? Add(User entity, string password)
        {
            var hashedPassword = BCrypt.HashPassword(password);
            entity.HashedPassword = hashedPassword;

            try
            {
                _context.Users.Add(entity);
                _context.SaveChanges();
                return entity.Id;
            }
            catch
            {
                return null;
            }
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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(string username)
        {
            var user = _context.Users
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

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}