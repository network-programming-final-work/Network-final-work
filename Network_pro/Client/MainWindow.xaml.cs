using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using Service;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IService1Callback
    {
        private Service1 client;
       
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddMessage(string str)
        {
            TextBlock t = new TextBlock();
            t.Text = str;
            t.Foreground = Brushes.Blue;
            listBoxMessage.Items.Add(t);
        }
        private static void ChangeState(Button btnStart, bool isStart, Button btnStop, bool isStop)
        {
            btnStart.IsEnabled = isStart;
            btnStop.IsEnabled = isStop;
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
            UserName = textBoxUserName.Text;
            client.Talk(UserName, textBoxTalk.Text);
        }
        public string UserName
        {
            get { return textBoxUserName.Text; }
            set { textBoxUserName.Text = value; }
        }
        private void textBoxTalk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                client.Talk(UserName, textBoxTalk.Text);
            }
        }

        public void ShowLogin(string loginUserName, int maxTables)
        {
            if (loginUserName == UserName)
            {
                MessageBox.Show("ok");
            }
            AddMessage(loginUserName + "进入大厅。");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            UserName = textBoxUserName.Text;
            this.Cursor = Cursors.Wait;
          //  client = new Service1(new InstanceContext(this));
            try
            {
                client.Login(textBoxUserName.Text);
               // serviceTextBlock.Text = "服务端地址：" + client.Endpoint.ListenUri.ToString();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("与服务端连接失败：" + ex.Message);
                return;
            }
            this.Cursor = Cursors.Arrow;
        }
    }
}
