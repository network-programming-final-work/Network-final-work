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
using System.ServiceModel;
using Service;
using client.ServiceReference1;
using System.IO;
using System.Windows.Forms;

namespace client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        bool isConnected = false;        
        ServiceReference1.ServiceChatClient client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();
        }

        void ConnectUser()
        {
            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(textBoxUsername.Text);
                textBoxUsername.IsEnabled = false;
                bConnectDisconnect.Content = "断开连接";
                isConnected = true;
            }
        }

        void DisconnectUser()
        {
            if (isConnected)
            {
                client.Disconnect(ID);
                client = null;
                textBoxUsername.IsEnabled = true;

                bConnectDisconnect.Content = "连接";
                isConnected = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else
            {
               ConnectUser();
            }
        }

        public void MessageCallBack(string message)
        {
            listBoxChat.Items.Add(message);
            listBoxChat.ScrollIntoView(listBoxChat.Items[listBoxChat.Items.Count - 1]);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }

        private void textBoxMessage_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                    client.SendMessage(textBoxMessage.Text, ID);
                textBoxMessage.Text = string.Empty;
            }
        }

        private async void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            string path="";
            StreamInfo sm;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fd.FileName;
            }
            if(path == "")
            {
                return;
            }
            client = new ServiceChatClient(new InstanceContext(this));
            FileInfo fileInfo = new FileInfo(path);
            Task task = client.sendID1Async(ID);
            Task task1 = client.sendFileAsync(fileInfo);
            while ( task1.IsCompleted == false)
            {
                await Task.Delay(100);
            }
            await task1;
            if (task1.IsCompleted == true) return;
            await Task.Delay(0);
        }

        public void ReceiveFile(FileInfo fileinfo,string path)
        {
            Stream stream = fileinfo.OpenRead();
            if (stream != null)
            {
                MemoryStream ms = new MemoryStream();
                stream.CopyTo(ms);
                int length = Convert.ToInt32(ms.Length);
                ms.Position = 0;
                stream.Close();
                byte[] bytes = new byte[length];
                int i = ms.Read(bytes, 0, length);            
                FileInfo fileInfo = new FileInfo(path);
                Stream stream1 = fileInfo.Open(FileMode.Create);
                while (i > 0)
                {
                    stream1.Write(bytes,0, length);
                    i = ms.Read(bytes, 0, length);
                }
                ms.Close();
                stream1.Close();
            }
             
        }

        private void receivebtn_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            client.sendid(ID);
            window1.Show();
        }
    }
}
