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
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        string text = "";
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


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string name = txtUserName.Text.ToString();
          
            string pwd = txtUserPwd.Password.ToString();
            string email = Email.Text;
            string repwd = txtReUserPwd.Password.ToString();
            string random_num = Random_Num.Text;
            if (text.Equals(random_num))
            {
                if (pwd.Equals(repwd))
                {
                    Service1Client service = new Service1Client();
                    string pwdEncrypt = service.MD5Encrypt(pwd);
                    if (service.AddUser(name, pwdEncrypt, email))
                    {
                        MessageBox.Show("注册状态：注册成功！");
                        LoginWindow login = new LoginWindow();
                        login.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show( "注册状态：确认密码错误！");
                }
            }
            else
            {
                MessageBox.Show("验证码错误");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
            }
           
        }

        /* private void txtReUserPwd_TextChanged(object sender, TextChangedEventArgs e)
         {
             string pwd = txtUserPwd.Password.ToString();

             while (true)
             {
                 if (PasswordStrength(pwd) == Strength.Strong)
                 {
                     txtReUserPwd.IsReadOnly = false;
                     break;
                 }
                 else
                 {
                     label.Content = "注册状态：密码强度太低！";
                     txtReUserPwd.IsReadOnly = true;
                     break;
                 }

             }


         }*/

        private void txtUserPwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string pwd = txtUserPwd.Password.ToString();
            string repwd = txtReUserPwd.Password.ToString();
            if (txtUserPwd.Password == "")
            {
                bd_Low.Background = Brushes.Gray;
                bd_Centre.Background = Brushes.Gray;
                bd_High.Background = Brushes.Gray;
            }
            else if (PasswordStrength(pwd) == Strength.Strong)
            {

                txtReUserPwd.IsEnabled = true;//显示确认新密码密码
                bd_Low.Background = Brushes.Green;
                bd_Centre.Background = Brushes.Green;
                bd_High.Background = Brushes.Green;
                txtReUserPwd.Opacity = 1;
            }
            else if (PasswordStrength(pwd) == Strength.Normal)
            {
                bd_Low.Background = Brushes.Red;
                bd_Centre.Background = Brushes.Red;
                bd_High.Background = Brushes.Gray;
                txtReUserPwd.IsEnabled = false;//禁止确认新密码密码

            }
            else if (PasswordStrength(pwd) == Strength.Weak)
            {
                bd_Low.Background = Brushes.Red;
                bd_Centre.Background = Brushes.Gray;
                bd_High.Background = Brushes.Gray;
                txtReUserPwd.IsEnabled = false;//禁止确认新密码密码
            }
            else
            {
                txtReUserPwd.IsEnabled = false;//禁止确认新密码密码
                txtReUserPwd.Opacity = 0.5;
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Service1Client service = new Service1Client();

            Random rd = new Random();
            string email = Email.Text;
            string title = "账号注册验证码";
            int i = rd.Next(100000, 1000000);
            text = i.ToString();

            int tag = service.Send(email,title, text);
            if (tag == 1)
            {
                MessageBox.Show("密码已发送到您的邮箱！");
            }
            if (tag == 0)
            {
                MessageBox.Show("密码...！");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }
    }
}

