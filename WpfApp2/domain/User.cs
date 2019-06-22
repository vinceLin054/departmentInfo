using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.domain
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Authority { get; set; }
        public String Activated { get; set; }

        public String ActivatedString { get { return Activated == "1" ? "是" : "否"; } }
        public User(string username, string password, string authority,String activated)
        {
            this.Username = username;
            this.Password = password;
            this.Authority = authority;
            this.Activated = activated;
        }
    }
}
