using SpellsReference.Models;
using System.Security.Principal;

namespace SpellsReference.Security
{
    public class CustomPrincipal : ICustomPrincipal
    {
        private CustomIdentity _customIdentity;

        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public int Id { get; private set; }

        public IIdentity Identity { get { return _customIdentity; } }

        public string LastName { get; private set; }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName[0]}.";
            }
        }

        public CustomPrincipal(CustomIdentity customIdentity, User user)
        {
            _customIdentity = customIdentity;
            Id = user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

        public bool IsInRole(string role)
        {
            // Change when roles are added
            return true;
        }
    }
}