using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.domain;
using WpfApp2.utils;

namespace WpfApp2.service
{
    class DepartmentService : Service
    {
        public List<Department> getList()
        {
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            List<Department> list=dBLink.getDepartList(null);
            dBLink.DBclose();
            return list;
        }

        public List<Department> getDepartmentListByAdminId(String AdminId)
        {
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            List<Department> list = dBLink.getDepartList(AdminId);
            dBLink.DBclose();
            return list;
        }

        public Boolean update(int Id,String Name,String Admin, String adminId)
        {
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            if (adminId != "NULL")
                adminId = "'" + adminId + "'";
            String sql = "UPDATE `departmental_manage_system`.`department` SET `name`='"+Name+"', `admin`='"+Admin+ "', `admin_id`="+adminId+"  WHERE (`id`='" + Id + "');";
            Boolean res=dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }

        public Boolean insert(String Name, String Admin,String adminId)
        {
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            if (adminId != "NULL")
                adminId = "'" + adminId + "'";
            String sql = "INSERT INTO `departmental_manage_system`.`department` (`name`, `admin`,`admin_id`,`activated`) VALUES ('" + Name+"', '"+Admin+"',"+adminId+",'1');";
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }

        public Boolean apply(String Name, String Admin, String adminId)
        {
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            if (adminId != "NULL")
                adminId = "'" + adminId + "'";
            String sql = "INSERT INTO `departmental_manage_system`.`department` (`name`, `admin`,`admin_id`,`activated`) VALUES ('" + Name + "', '" + Admin + "'," + adminId + ",'0');";
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }

        public Boolean delete(String Id)
        {
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            String sql = "delete from department where id="+Id+"";
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }

        public Boolean active(String Id)
        {
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            String sql = "UPDATE `departmental_manage_system`.`department` SET `activated`='1'  WHERE (`id`='" + Id + "');";
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }
    }
}
