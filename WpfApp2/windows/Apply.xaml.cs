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
    /// Apply.xaml 的交互逻辑
    /// </summary>
    public partial class Apply : Window
    {
        Index parent;
        String username;
        DepartmentService departmentService = new DepartmentService();

        public Apply(Index parent,String username)
        {
            InitializeComponent();
            this.parent = parent;
            this.username = username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (departmentService.apply(NameText.Text, AdminText.Text, username))
                MessageBox.Show("申请成功，请联系超级管理员审核激活");
            this.Close();
            parent.refreash();
        }
    }
}
