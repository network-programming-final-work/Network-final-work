using DZY_NoteSystem.LoginServiceReference;
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

namespace DZY_NoteSystem
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private enum Strength
        {
            Invalid = 0, //无效密码
            Weak = 1, //低强度密码
            Normal = 2, //中强度密码
            Strong = 3 //高强度密码
        };

        private static Strength PasswordStrength(string password)
        {
            //空字符串强度值为0
            if (password == "") return Strength.Invalid;
            //字符统计
            int iNum = 0, iLtt = 0, iSym = 0;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9') iNum++;
                else if (c >= 'a' && c <= 'z') iLtt++;
                else if (c >= 'A' && c <= 'Z') iLtt++;
                else iSym++;
            }
            if (iLtt == 0 && iSym == 0) return Strength.Weak; //纯数字密码
            if (iNum == 0 && iLtt == 0) return Strength.Weak; //纯符号密码
            if (iNum == 0 && iSym == 0) return Strength.Weak; //纯字母密码
            if (password.Length <= 6) return Strength.Weak; //长度不大于6的密码
            if (iLtt == 0) return Strength.Normal; //数字和符号构成的密码
            if (iSym == 0) return Strength.Normal; //数字和字母构成的密码
            if (iNum == 0) return Strength.Normal; //字母和符号构成的密码
            if (password.Length <= 10) return Strength.Normal; //长度不大于10的密码
            return Strength.Strong; //由数字、字母、符号构成的密码
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string name = txtUserName.Text.ToString();
            string pwd = txtUserPwd.Password.ToString();
            Service1Client service = new Service1Client();
            if (PasswordStrength(pwd) == Strength.Strong)
            {
                 bool login = service.IsLogin(name, pwd);
                if (login)
                {
                    MessageBox.Show("登录成功！");

                    System.Threading.Thread.Sleep(1000);
                    MainWindow main = new MainWindow(name);
                    main.Show();

                    this.Close();
                }
                else
                {
                    label.Content = "状态提示：登录失败，请重新输入！";
                }
            }
            else
            {
                label.Content = "密码强度太低！";
            }
           
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.Show();
            this.Close();
        }
    }
}
