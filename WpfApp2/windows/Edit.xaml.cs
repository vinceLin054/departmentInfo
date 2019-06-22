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
    /// Edit.xaml 的交互逻辑
    /// </summary>
    public partial class Edit : Window
    {
        DepartmentService departmentService = new DepartmentService();
        UserService userService = new UserService();
        Index parent;
        public Edit(int Id,String Name,String Admin,String AdminId,Index parent)
        {
            InitializeComponent();
            IdText.Text = Id.ToString();
            NameText.Text = Name;
            AdminText.Text = Admin;
            this.parent = parent;
            List<User> list = userService.getList();
            Username.Items.Add("空");
            for(int i = 0; i < list.Count; i++)
            {
                Username.Items.Add(list[i].Username);
                if(list[i].Username==AdminId)
                    Username.SelectedIndex = i+1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String username= Username.Text;
            if (username == "空")
                username = "NULL";
            departmentService.update(int.Parse(IdText.Text), NameText.Text, AdminText.Text,username);
            parent.refreash();
            this.Close();
        }
    }
}
