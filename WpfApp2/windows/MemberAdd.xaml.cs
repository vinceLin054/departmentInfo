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
    /// MemberAdd.xaml 的交互逻辑
    /// </summary>
    public partial class MemberAdd : Window
    {
        Index parent;
        int departmentId;
        DepartmentService departmentService = new DepartmentService();
        MemberService memberService = new MemberService();
        public MemberAdd(Index parent,int departmentId)
        {
            InitializeComponent();
            this.parent = parent;
            this.departmentId = departmentId;
            List<Department> list=departmentService.getList();
            foreach(Department department in list){
                if (department.Id == departmentId)
                    DepartmentName.Text = department.Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String name = Name.Text;
            String sex = Sex.Text;
            String position = Position.Text;
            String phone = Phone.Text;
            String departmentName = DepartmentName.Text;
            memberService.add(name, sex, position, phone, departmentId);
            this.Close();
            parent.refreashMember();
        }
    }
}
