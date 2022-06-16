using DZY_NoteSystem.LoginServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            // txtUserName.Text = "请输入用户名";
            // txtUserName.Foreground = Brushes.Gray;
            txtUserName.Text = GetSettingString("userName");
            txtUserPwd.Password = GetSettingString("password");
           
            if (GetSettingString("isRemember") == "true")
            {
                ckbRemember.IsChecked = true;
            }
            else
            {
                ckbRemember.IsChecked = false;
            }
          /*  if (GetSettingString("isLogin") == "true")
            {
                
                btnLogin_Click(null, null);
            }
            else
            {
                LoginCheckBox.IsChecked = false;
            }*/
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
            string pwdEncrypt = service.MD5Encrypt(pwd);
            bool login = service.IsLogin(name, pwdEncrypt);
            if (Convert.ToBoolean(ckbRemember.IsChecked))
            {
                UpdateSettingString("userName", txtUserName.Text);
                UpdateSettingString("password", txtUserPwd.Password);
                UpdateSettingString("isRemember", "true");
                if (login)
                {
                   // MessageBox.Show("登录成功！");

                    System.Threading.Thread.Sleep(1000);
                    MainWindow main = new MainWindow(name);
                    main.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("登录失败，请重新输入！");
                }
            }
            else
            {
                UpdateSettingString("userName", "");
                UpdateSettingString("password", "");
                UpdateSettingString("isRemember", "");
                if (login)
                {
                   // MessageBox.Show("登录成功！");

                    System.Threading.Thread.Sleep(1000);
                    MainWindow main = new MainWindow(name);
                    main.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("登录失败，请重新输入！");
                }
            }

          
              
               
            
           
           
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.Show();
            this.Close();
        }

        private void txtUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUserName.Text = "";
        }

        private void txtUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            txtUserName.Text = "请输入用户名";
            txtUserName.Foreground = Brushes.Gray;
        }

       /* private void txtUserPwd_LostFocus(object sender, RoutedEventArgs e)
        {
            txtUserPwd.Password = "";
        }

        private void txtUserPwd_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUserPwd.Password = "请输入密码";
            txtUserPwd.Foreground = Brushes.Gray;
        }*/

        /// <summary>
        /// 读取客户设置
        /// </summary>
        /// <param name="settingName"></param>
        /// <returns></returns>
        public static string GetSettingString(string settingName)
        {
            try
            {
                string settingString = ConfigurationManager.AppSettings[settingName].ToString();
                return settingString;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 更新设置
        /// </summary>
        /// <param name="settingName"></param>
        /// <param name="valueName"></param>
        public static void UpdateSettingString(string settingName, string valueName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (ConfigurationManager.AppSettings[settingName] != null)
            {
                config.AppSettings.Settings.Remove(settingName);
            }
            config.AppSettings.Settings.Add(settingName, valueName);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void btnRegister_Copy_Click(object sender, RoutedEventArgs e)
        {
            FindPassword findPwd = new FindPassword();
            findPwd.Show();
            this.Close();
        }
    }
}
