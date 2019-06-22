using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2.domain;
using WpfApp2.service;

namespace WpfApp2.windows
{
    /// <summary>
    /// MemberEdit.xaml 的交互逻辑
    /// </summary>
    public partial class MemberEdit : Window
    {
        Index parent;
        int departmentId;
        DepartmentService departmentService = new DepartmentService();
        MemberService memberService = new MemberService();
        public MemberEdit(Index parent, int id,String name,String sex,String position,String phone,int departmentId)
        {
            InitializeComponent();
            this.departmentId = departmentId;
            this.parent = parent;
            Id.Text = id.ToString();
            Name.Text = name;
            int index = -1;
            for(int i = 0; i < Sex.Items.Count; i++)
            {
                String nowSex = Sex.Items[i].ToString().Split(':')[1];
                nowSex=nowSex.Substring(1);
                if (sex == nowSex)
                {
                    index = i;
                    break;
                }
            }
            Sex.SelectedIndex = index;
            Position.Text = position;
            Phone.Text = phone;
            List<Department> list = departmentService.getList();
            foreach (Department department in list)
            {
                if (department.Id == departmentId)
                    DepartmentName.Text = department.Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id=int.Parse(Id.Text);
            String name=Name.Text;
            String sex=Sex.Text;
            String position=Position.Text;
            String phone=Phone.Text;
            memberService.update(id, name, sex, position, phone, departmentId);
            this.Close();
            parent.refreashMember();
        }
    }
}
