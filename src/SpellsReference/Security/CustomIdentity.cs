using System.Security.Principal;
using System.Web.Security;

namespace SpellsReference.Security
{
    public class CustomIdentity : IIdentity
    {
        private FormsAuthenticationTicket _ticket;

        public string AuthenticationType
        {
            get
            {
                return "Custom";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return _ticket.Name;
            }
        }

        public CustomIdentity(FormsAuthenticationTicket ticket)
        {
            _ticket = ticket;
        }
    }
}