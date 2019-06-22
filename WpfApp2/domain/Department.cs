using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.domain
{
    public class Department
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Admin { get; set; }

        public String AdminId { get; set; }

        public String Activated { get; set; }

        public String ActivatedString { get { return Activated == "1" ? "是" : "否"; } }

        public Department(int id, string name, String admin,String adminId,String activated)
        {
            this.Id = id;
            this.Name = name;
            this.Admin = admin;
            this.AdminId = adminId;
            this.Activated = activated;
        }

        public override string ToString()
        {
            return "Id:"+Id+"Name:"+Name+"Admin:"+Admin;
        }
    }
}
