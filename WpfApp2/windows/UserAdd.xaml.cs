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
using WpfApp2.service;

namespace WpfApp2.windows
{
    /// <summary>
    /// UserAdd.xaml 的交互逻辑
    /// </summary>
    public partial class UserAdd : Window
    {
        Index index;
        UserService userService = new UserService();
        public UserAdd(Index index)
        {
            InitializeComponent();
            this.index = index;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String username = Username.Text;
            String password = Password.Password;
            String repassword = RePassword.Password;
            if (password != repassword)
                MessageBox.Show("两次密码不一致");
            if (userService.isExist(username))
            {
                MessageBox.Show("用户名已存在");
            }
            else
            {
                userService.add(username, password);
                this.Close();
                index.refreashUser();
            }
        }
    }
}
