using DZY_NoteSystem.LoginServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace DZY_NoteSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Button oldBtn = new Button();
        public MainWindow(string n)
        {
            InitializeComponent();
            userName.Content = n;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            btn.Foreground = Brushes.Red;
            oldBtn.Foreground = Brushes.Black;
            oldBtn = btn;
            frame1.Source = new Uri(btn.Tag.ToString(), UriKind.Relative);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
