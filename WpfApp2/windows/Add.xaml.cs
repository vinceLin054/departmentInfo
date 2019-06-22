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
    /// Add.xaml 的交互逻辑
    /// </summary>
    public partial class Add : Window
    {
        Index parent;
        DepartmentService departmentService = new DepartmentService();
        UserService userService = new UserService();
        public Add(Index parent)
        {
            InitializeComponent();
            this.parent = parent;
            List<User> list=userService.getList();
            Username.Items.Add("空");
            foreach(User user in list)
            {
                Username.Items.Add(user.Username);
            }
            Username.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String name = NameText.Text;
            String admin = AdminText.Text;
            String username = Username.Text;
            if (username == "空")
                username = "NULL";
            departmentService.insert(name, admin, username);
            parent.refreash();
            this.Close();
        }
    }
}
