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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.domain;
using WpfApp2.service;
using WpfApp2.windows;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        UserService userService = new UserService();
        static String name;
        public MainWindow()
        {
            InitializeComponent();
        }

        public static String getname()
        {
            return name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String username = usernameBox.Text;
            String password = passwordBox.Password;
            User user = userService.login(username, password);
            if (user == null)
            {
                MessageBox.Show("账号或密码错误");
            }
            else if (user.Activated == "0")
            {
                MessageBox.Show("账号未激活，请联系管理员激活");
            }
            else
            {
                this.Hide();
                name = usernameBox.Text;
                new Index(this,user).Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (userService.isExist(usernameBox.Text))
            {
                MessageBox.Show("用户名已存在");
            }
            else if (userService.regist(usernameBox.Text,passwordBox.Password))
                MessageBox.Show("注册成功，请联系管理员激活");
        }
    }
}
