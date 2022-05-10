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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddColorMessage(string str, SolidColorBrush color)
        {
            TextBlock t = new TextBlock();
            t.Text = str;
            t.Foreground = color;
            listBoxMessage.Items.Add(t);
        }
        public void ShowTalk(string userName, string message)
        {
            AddColorMessage(string.Format("{0}：{1}", userName, message), Brushes.Black);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          //  client.Talk(tableIndex, UserName, textBoxTalk.Text);
        }
    }
}
