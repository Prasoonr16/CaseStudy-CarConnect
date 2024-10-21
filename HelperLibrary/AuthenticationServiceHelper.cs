using System;
using DAO;

namespace HelperLibrary
{
    public class AuthenticationServiceHelper
    {
        AuthenticationService authenticationService = null;

        public AuthenticationServiceHelper()
        {
            authenticationService = new AuthenticationService();
        }

        public bool authenticateCustomer(string username, string password)
        {
            return authenticationService.AuthenticateCustomer(username, password);
        }

        public bool authenticateAdmin(string username, string password)
        {
            return authenticationService.AuthenticateAdmin(username, password);
        }
    }
}
