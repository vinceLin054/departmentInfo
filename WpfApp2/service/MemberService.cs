using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.domain;
using WpfApp2.utils;

namespace WpfApp2.service
{
    class MemberService : Service
    {
        public List<Member> getList(int id)
        {
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            List<Member> list = dBLink.getMemberListByDepartmentId(id);
            dBLink.DBclose();
            return list;
        }

        public Boolean add(String name,String sex,String position,String phone,int depmtId)
        {
            String sql = "INSERT INTO `departmental_manage_system`.`member` (`name`, `sex`, `position`, `phone`, `department_id`) " +
                "VALUES ('"+name+"', '"+sex+"', '"+position+"', '"+phone+"', '"+depmtId+"');";
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            Boolean res=dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }

        public Boolean update(int id,String name, String sex, String position, String phone, int depmtId)
        {
            String sql = "UPDATE `departmental_manage_system`.`member` SET `name`='"+name+"', `sex`='"+sex+"', `position`='"+position+"', `phone`='"+phone+"', `department_id`='"+depmtId+"' WHERE (`id`='"+id+"');";
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }

        public Boolean delete(String id)
        {
            String sql = "delete from member where id="+id;
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }

        public Boolean deleteAllByDepemtId(int id)
        {
            String sql = "delete from member where department_id=" + id;
            DBlink dBLink = new DBlink();
            dBLink.DBconn();
            Boolean res = dBLink.UpdataDeletAdd(sql);
            dBLink.DBclose();
            return res;
        }
    }
}
