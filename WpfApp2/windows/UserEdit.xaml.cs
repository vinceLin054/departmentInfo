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
    /// UserEdit.xaml 的交互逻辑
    /// </summary>
    public partial class UserEdit : Window
    {
        Index index;
        UserService userService = new UserService();

        public UserEdit(Index index,String username)
        {
            InitializeComponent();
            this.index = index;
            Username.Text = username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String username = Username.Text;
            String password = Password.Password;
            String repassword = RePassword.Password;
            if (password != repassword)
                MessageBox.Show("两次密码不一致");
            else
            {
                userService.update(username, password);
                this.Close();
                MessageBox.Show("修改成功");
                index.refreashUser();
            }
        }
    }
}
