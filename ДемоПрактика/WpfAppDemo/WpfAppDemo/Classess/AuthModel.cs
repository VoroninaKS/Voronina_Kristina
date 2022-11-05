using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemo.Classess
{
    public class AuthModel
    {
        public string Role { get; set; }

        public string UserName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public AuthModel (string role, string userName, string login, string password)
        {
            Role = role;
            UserName = userName;
            Login = login;
            Password = password;
        }
    }
}
