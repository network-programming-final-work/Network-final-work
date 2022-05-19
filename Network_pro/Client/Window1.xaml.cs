using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using client.ServiceReference1;

namespace client
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window, IServiceChatCallback
    {
        ServiceChatClient client;
        public Window1()
        {
            InitializeComponent();
            client = new ServiceChatClient(new InstanceContext(this));
            List<FileInfo> filelist = client.getFileList().ToList();
            foreach (FileInfo i in filelist)
            {
                listbox.Items.Add(i.Name);
            }
        }

        public void MessageCallBack(string message)
        {
            throw new NotImplementedException();
        }

        public void ReceiveFile(FileInfo fileinfo, string path)
        {
            throw new NotImplementedException();
        }

        private async void listbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            string path = fd.SelectedPath;
            List<FileInfo> filelist = client.getFileList().ToList();
            string select = listbox.SelectedItem.ToString();
            int j = 0;
            Task task = null;
            foreach (FileInfo i in filelist)
            {
                if(i.Name == select)
                {                 
                    path = path + "\\" + i.Name;
                    task = client.singleAsync(j, path);
                    break;              
                }
                j++;
            }
            this.Close();
            await task;
            if(task.IsCompleted) System.Windows.MessageBox.Show("下载完成！");
            
        }
    }
}
