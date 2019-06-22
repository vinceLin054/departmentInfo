using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using WpfApp2.domain;

namespace WpfApp2.utils
{
    class DBlink
    {
        MySqlConnection sqlCnn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        public Boolean DBtag=false;
        public Boolean DBconn()
        {
            sqlCnn.ConnectionString = "server = '127.0.0.1'; uid = 'root'; pwd = 'LWs39123'; database = 'departmental_manage_system';charset=utf8;";//连接字符串
            sqlCmd.Connection = sqlCnn;
            try
            {
                sqlCnn.Open();
                DBtag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
            }
            return DBtag;
        }
       
        public Boolean search(String str)
        {
            sqlCmd.CommandText = str;
            Boolean tag = false;
            MySqlDataReader rec = sqlCmd.ExecuteReader();
            while (rec.Read())
            {
                tag = true;
            }
            rec.Close();
            return tag;
        }
        public Boolean UpdataDeletAdd(string str)
        {
            sqlCmd.CommandText = str;
            return sqlCmd.ExecuteNonQuery()>0;  
        }
        public void DBclose()
        {
            sqlCnn.Close();
        }

        public List<Department> getDepartList(String AdminId)
        {
            String sql = "select * from department";
            if (AdminId != null)
                sql += " where admin_id='" + AdminId + "'";
            sqlCmd.CommandText = sql;
            MySqlDataReader rec = sqlCmd.ExecuteReader();
            List<Department> list = new List<Department>();
            while (rec.Read())
            {
                int id = rec.GetInt32(0);
                String name = rec.GetString(1);
                String admin = rec.GetString(2);
                String adminId = null;
                if (rec["admin_id"] != DBNull.Value)
                    adminId = rec["admin_id"].ToString();
                Department department = new Department(id,name,admin,adminId,rec["activated"].ToString());
                list.Add(department);
            }
            return list;
        }

        public List<Member> getMemberListByDepartmentId(int departmentId)
        {
            String sql = "select * from member where department_id="+departmentId;
            sqlCmd.CommandText = sql;
            MySqlDataReader rec = sqlCmd.ExecuteReader();
            List<Member> list = new List<Member>();
            while (rec.Read())
            {
                int id = rec.GetInt32(0);
                String name = rec.GetString(1);
                String sex = rec.GetString(2);
                String position = rec.GetString(3);
                String phone = rec.GetString(4);
                Member member = new Member(id, name, sex,position,phone,departmentId);
                list.Add(member);
            }
            return list;
        }

        public User getUserByUserNamePwd(String username,String password)
        {
            String sql = "select * from user where username='" + username + "' and password='" + password + "'";
            sqlCmd.CommandText = sql;
            MySqlDataReader rec = sqlCmd.ExecuteReader();
            if (rec.Read())
            {
                return new User(rec.GetString(0), rec.GetString(1), rec.GetString(2),rec.GetString(3));
            }
            return null;
        }

        public List<User> getUserList()
        {
            String sql = "select * from user where authority = '1'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, sqlCnn);
            DataSet ds = new DataSet();
            da.Fill(ds,"user");
            DataTable dt = ds.Tables["user"];
            DataView dv = new DataView(dt);
            List<User> list = new List<User>();
            foreach (DataRowView drv in dv)
            {
                list.Add(new User(drv[0].ToString(), drv[1].ToString(), drv[2].ToString(), drv[3].ToString()));
            }
            return list;
        }
    }
}
