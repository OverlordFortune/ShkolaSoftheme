using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._1
{
    interface IAuthenticator
    {
        string AuthenticateUser(IUser user);
    }
}
