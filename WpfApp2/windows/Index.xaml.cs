using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using WpfApp2.domain;
using WpfApp2.service;
using WpfApp2.utils;

namespace WpfApp2.windows
{
    /// <summary>
    /// Index.xaml 的交互逻辑
    /// </summary>
    public partial class Index : Window
    {
        DepartmentService departmentServcie = new DepartmentService();
        MemberService memberService = new MemberService();
        UserService userService = new UserService();
        Service service;
        Window parent;
        delegate String namehandler();
        User user;
        int departmentId = 0;
        public Index(Window parent,User user)
        {
            InitializeComponent();
            namehandler ih= new namehandler(MainWindow.getname);
            name.Content = ih();
            this.parent = parent;
            this.user = user;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            hiddenMemberPart();
            hiddenUserPart();
            departmentDataGrid.ItemsSource = null;
            List<Department> list;
            if (user.Authority == "0")
                list = departmentServcie.getList();
            else
                list = departmentServcie.getDepartmentListByAdminId(user.Username);
            departmentDataGrid.ItemsSource = list;
            showDepartmentPart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Department select = (Department)departmentDataGrid.SelectedItem;
            if (select == null)
            {
                MessageBox.Show("请先选中要修改的部门");
            }
            else if (select.ActivatedString == "否")
            {
                MessageBox.Show("激活后才可编辑");
            }
            else
            {
                new Edit(select.Id, select.Name, select.Admin, select.AdminId, this).Show();
            }
        }

        public void refreash()
        {
            hiddenMemberPart();
            hiddenUserPart();
            departmentDataGrid.ItemsSource = null;
            List<Department> list;
            if (user.Authority == "0")
                list = departmentServcie.getList();
            else
                list = departmentServcie.getDepartmentListByAdminId(user.Username);
            departmentDataGrid.ItemsSource = list;
            showDepartmentPart();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Add(this).Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Department select = (Department)departmentDataGrid.SelectedItem;
            if (select != null)
            {
                MessageBoxResult result=MessageBox.Show("是否确认删除?", "删除", MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    service = departmentServcie;
                    service.delete(select.Id.ToString());
                    refreash();
                }
            }
            else
            {
                MessageBox.Show("请先选中要删除的数据");
            }
        }

        private void showDepartmentPart()
        {
            departmentDataGrid.Visibility = Visibility.Visible;
            if (user.Authority == "0")
            {
                departmentEdit.Visibility = Visibility.Visible;
                departmentAdd.Visibility = Visibility.Visible;
                departmentDelete.Visibility = Visibility.Visible;
                AdminUser.Visibility = Visibility.Visible;
                activateDepmt.Visibility = Visibility.Visible;
                DeptmtName.Width = 150;
            }
            else
            {
                apply.Visibility = Visibility.Visible;
            }
            showMember.Visibility = Visibility.Visible;
        }

        private void hiddenDepartmentPart()
        {
            departmentDataGrid.Visibility = Visibility.Hidden;
            departmentEdit.Visibility = Visibility.Hidden;
            departmentAdd.Visibility = Visibility.Hidden;
            departmentDelete.Visibility = Visibility.Hidden;
            showMember.Visibility = Visibility.Hidden;
            activateDepmt.Visibility = Visibility.Hidden;
            apply.Visibility = Visibility.Hidden;
        }

        private void showMemberPart()
        {
            memberDataGrid.Visibility = Visibility.Visible;
            memberBack.Visibility = Visibility.Visible;
            memberAdd.Visibility = Visibility.Visible;
            memberEdit.Visibility = Visibility.Visible;
            memberDelete.Visibility = Visibility.Visible;
            memberExport.Visibility = Visibility.Visible;
            memberImport.Visibility = Visibility.Visible;
        }

        private void hiddenMemberPart()
        {
            memberDataGrid.Visibility = Visibility.Hidden;
            memberBack.Visibility = Visibility.Hidden;
            memberAdd.Visibility = Visibility.Hidden;
            memberEdit.Visibility = Visibility.Hidden;
            memberDelete.Visibility = Visibility.Hidden;
            memberExport.Visibility = Visibility.Hidden;
            memberImport.Visibility = Visibility.Hidden;
        }

        private void showUserPart()
        {
            userDataGrid.Visibility = Visibility.Visible;
            userEdit.Visibility = Visibility.Visible;
            if (user.Authority == "0")
            {
                userAdd.Visibility = Visibility.Visible;
                userDelete.Visibility = Visibility.Visible;
                activate.Visibility = Visibility.Visible;
            }
        }
        private void hiddenUserPart()
        {
            userDataGrid.Visibility = Visibility.Hidden;
            userAdd.Visibility = Visibility.Hidden;
            userEdit.Visibility = Visibility.Hidden;
            userDelete.Visibility = Visibility.Hidden;
            activate.Visibility = Visibility.Hidden;
        }

        private void ShowMember_Click(object sender, RoutedEventArgs e)
        {
            Department select = (Department)departmentDataGrid.SelectedItem;
            if (select == null)
            {
                MessageBox.Show("请先选中要查看的部门");
            }
            else if (select.ActivatedString == "否")
            {
                MessageBox.Show("部门未激活,请联系超级管理员激活");
            }
            else
            {
                departmentId = select.Id;
                hiddenDepartmentPart();
                List<Member> members = memberService.getList(select.Id);
                memberDataGrid.ItemsSource = null;
                memberDataGrid.ItemsSource = members;
                showMemberPart();
            }
        }

        private void MemberBack_Click(object sender, RoutedEventArgs e)
        {
            refreash();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void MemberAdd_Click(object sender, RoutedEventArgs e)
        {
            Department select = (Department)departmentDataGrid.SelectedItem;
            new MemberAdd(this,select.Id).Show();
        }

        public void refreashMember()
        {
            Department select = (Department)departmentDataGrid.SelectedItem;
            hiddenDepartmentPart();
            List<Member> members = memberService.getList(select.Id);
            memberDataGrid.ItemsSource = null;
            memberDataGrid.ItemsSource = members;
            showMemberPart();
        }

        public void refreashUser()
        {
            hiddenMemberPart();
            hiddenDepartmentPart();
            userDataGrid.ItemsSource = null;
            List<User> list = new List<User>();
            if (user.Authority == "0")
                list = userService.getList();
            else
                list.Add(user);
            userDataGrid.ItemsSource = list;
            showUserPart();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Show();
        }

        private void MemberEdit_Click(object sender, RoutedEventArgs e)
        {
            Department department = (Department)departmentDataGrid.SelectedItem;
            Member member = (Member)memberDataGrid.SelectedItem;
            if (member != null)
                new MemberEdit(this, member.Id, member.Name, member.Sex, member.Position, member.Phone, department.Id).Show();
            else
                MessageBox.Show("请选择要编辑的成员");
        }

        private void MemberDelete_Click(object sender, RoutedEventArgs e)
        {
            Member member = (Member)memberDataGrid.SelectedItem;
            if (member != null)
            {
                MessageBoxResult result = MessageBox.Show("是否确认删除?", "删除", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    memberService.delete(member.Id.ToString());
                    refreashMember();
                }
            }
            else
            {
                MessageBox.Show("请先选中要删除的数据");
            }
        }

        private void MemberBack_Click_1(object sender, RoutedEventArgs e)
        {
            hiddenMemberPart();
            showDepartmentPart();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            hiddenMemberPart();
            hiddenDepartmentPart();
            userDataGrid.ItemsSource = null;
            List<User> list = new List<User>();
            if (user.Authority == "0")
                list = userService.getList();
            else
                list.Add(user);
            userDataGrid.ItemsSource = list;
            showUserPart();
        }

        private void UserAdd_Click(object sender, RoutedEventArgs e)
        {
            new UserAdd(this).Show();
        }

        private void UserEdit_Click(object sender, RoutedEventArgs e)
        {       
            User selectUser = (User)userDataGrid.SelectedItem;
            if (selectUser != null)
                new UserEdit(this, selectUser.Username).Show();
            else
                MessageBox.Show("请选择要修改密码的用户");
        }

        private void UserDelete_Click(object sender, RoutedEventArgs e)
        {
            User selectUser = (User)userDataGrid.SelectedItem;
            if (selectUser != null)
            {
                MessageBoxResult result = MessageBox.Show("是否确认删除?", "删除", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    userService.delete(selectUser.Username);
                    refreashUser();
                }
            }
            else
            {
                MessageBox.Show("请先选中要删除的数据");
            }
        }

        private void Activate_Click(object sender, RoutedEventArgs e)
        {
            User selectUser = (User)userDataGrid.SelectedItem;
            if (selectUser == null)
            {
                MessageBox.Show("请先选中要激活的用户");
            }
            else if (selectUser.ActivatedString == "是")
            {
                MessageBox.Show("该用户已激活");
            }
            else
            {
                userService.activate(selectUser.Username);
                refreashUser();
            }
        }

        private void ActivateDepmt_Click(object sender, RoutedEventArgs e)
        {
            Department selectDepartment = (Department)departmentDataGrid.SelectedItem;
            if (selectDepartment == null)
            {
                MessageBox.Show("请先选中要激活的部门");
            }
            else if (selectDepartment.ActivatedString == "是")
            {
                MessageBox.Show("该部门已激活");
            }
            else
            {
                departmentServcie.active(selectDepartment.Id.ToString());
                refreash();
            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            new Apply(this,user.Username).Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string localFilePath = "";
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "Excel表格（*.xls）|*.xls";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                ExcelUtils.export(localFilePath, memberService.getList(departmentId));
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("请使用下载的模板进行导入!!!!\n是否下载模板(选否则直接选择文件导入)", "提示", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                string localFilePath = "";
                //string localFilePath, fileNameExt, newFileName, FilePath; 
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                //设置文件类型 
                sfd.Filter = "Excel表格（*.xls）|*.xls";

                //设置默认文件类型显示顺序 
                sfd.FilterIndex = 1;

                //保存对话框是否记忆上次打开的目录 
                sfd.RestoreDirectory = true;

                //点了保存按钮进入 
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    localFilePath = sfd.FileName.ToString(); //获得文件路径 
                    ExcelUtils.downModel(localFilePath);
                }
            }
            if(result == MessageBoxResult.No)
            {
                System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
                fileDialog.Multiselect = true;
                fileDialog.Title = "请选择文件";
                fileDialog.Filter = "所有文件(*xls*)|*.xls*"; //设置要选择的文件的类型
                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string file = fileDialog.FileName;//返回文件的完整路径                
                    ExcelUtils.import(file, departmentId);
                    refreashMember();
                }
            }
        }
    }
}
