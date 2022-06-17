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
    /// FindPassword.xaml 的交互逻辑
    /// </summary>
    /// 


    public partial class FindPassword : Window
    {
        public FindPassword()
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

        private void send_num_Click(object sender, RoutedEventArgs e)
        {
            Service1Client service = new Service1Client();

            Random rd = new Random();
            string email = Email.Text;
            string title = "找回密码验证码";
            int i = rd.Next(100000, 1000000);
            text = i.ToString();

            int tag = service.Send(email, title,text);
            if (tag == 1)
            {
                MessageBox.Show("密码已发送到您的邮箱！");
            }
            if (tag == 0)
            {
                MessageBox.Show("密码...！");
            }
        }

        private void txtUserPwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string pwd = NewPwd.Password.ToString();
         
            if (NewPwd.Password == "")
            {
                bd_Low.Background = Brushes.Gray;
                bd_Centre.Background = Brushes.Gray;
                bd_High.Background = Brushes.Gray;
                FixPwd.IsEnabled = false;
                FixPwd.Opacity = 0.5;
            }
            else if (PasswordStrength(pwd) == Strength.Strong)
            {

                FixPwd.IsEnabled = true;
                bd_Low.Background = Brushes.Green;
                bd_Centre.Background = Brushes.Green;
                bd_High.Background = Brushes.Green;
               
            }
            else if (PasswordStrength(pwd) == Strength.Normal)
            {
                bd_Low.Background = Brushes.Red;
                bd_Centre.Background = Brushes.Red;
                bd_High.Background = Brushes.Gray;
                FixPwd.IsEnabled = false;
                FixPwd.Opacity = 0.5;

            }
            else if (PasswordStrength(pwd) == Strength.Weak)
            {
                bd_Low.Background = Brushes.Red;
                bd_Centre.Background = Brushes.Gray;
                bd_High.Background = Brushes.Gray;
                FixPwd.IsEnabled = false;
                FixPwd.Opacity = 0.5;
            }
            else
            {
                FixPwd.IsEnabled = false;
                FixPwd.Opacity = 0.5;
            }



        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Service1Client service = new Service1Client();
            string newpwd = NewPwd.Password.ToString();
            string username = UserName.Text;
            string email = Email.Text;
           
            
                if (text.Equals(Random_Number.Text))
                {
                string newpwdEncrypt = service.MD5Encrypt(newpwd);
                    bool flag = service.UpdatePwd(username, newpwdEncrypt, email);
                    if (flag)
                    {
                        MessageBox.Show("密码修改成功！");

                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }


                else
                {
                    MessageBox.Show("验证码错误！");
                }
            
           

         

            // bool updatepwd = service.UpdatePwd(username, newpwd, email);

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }
    }
}
