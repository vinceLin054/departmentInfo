using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.domain
{
    public class Member
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Sex { get; set; }
        public String Position { get; set; }
        public String Phone { get; set; }

        public int DepartmentId { get; set; }

        public Member(int id, string name, string sex, string position, string phone,int departmentId)
        {
            this.Id = id;
            this.Name = name;
            this.Sex = sex;
            this.Position = position;
            this.Phone = phone;
            this.DepartmentId = departmentId;
        }

    }
}
