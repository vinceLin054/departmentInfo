using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.domain;
using WpfApp2.utils;

namespace WpfApp2.service
{
    class UserService :Service
    {
        public Boolean isExist(String username)
        {
            String sql = "select * from user where username='" + username + "'";
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            Boolean res = dBLink.search(sql);
            dBLink.DBclose();
            return res;
        }
        public User login(String username,String password)
        {
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            User user=dBLink.getUserByUserNamePwd(username, password);
            dBLink.DBclose();
            return user;
        }

        public Boolean regist(String username,String password)
        {
            String sql = "INSERT INTO `departmental_manage_system`.`user` (`username`, `password`, `authority`,`activated`) VALUES ('" + username + "', '" + password + "', '1','0');";
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }

        public Boolean activate(String username)
        {
            String sql = "UPDATE `departmental_manage_system`.`user` SET `activated`='1' WHERE (`username`='" + username + "');";
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }
        public List<User> getList()
        {
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            List<User> list = dBLink.getUserList();
            dBLink.DBclose();
            return list;
        }

        public Boolean add(String username,String password)
        {
            String sql = "INSERT INTO `departmental_manage_system`.`user` (`username`, `password`, `authority`,`activated`) VALUES ('" + username + "', '" + password + "', '1','1');";
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }

        public Boolean update(String username,String password)
        {
            String sql = "UPDATE `departmental_manage_system`.`user` SET `password`='"+password+"' WHERE (`username`='"+username+"');";
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }

        public Boolean delete(String username)
        {
            String sql = "DELETE FROM USER WHERE username='" + username + "'";
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }
    }
}
