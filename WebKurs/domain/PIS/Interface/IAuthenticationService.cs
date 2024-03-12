namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAuthenticationService
    {
        public bool Authenticate(string username, string password,Dictionary<string, string> error);

    }
}
