using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;
        List<FileInfo> dictionary = new List<FileInfo>();
        int file_id;
        int dowloaduserid;
        Object obj = new object();
        public int Connect(string name)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextId,
                UserName = name,
                operationContext = OperationContext.Current,
            };
            nextId++;

            SendMessage(": " + user.UserName + "进入聊天!", 0);
            users.Add(user);

            return user.ID;
        }

        public void Disconnect(int identificator)
        {
            var user = users.FirstOrDefault(i => i.ID == identificator); //поиск usera
            if (user != null)
            {
                users.Remove(user);
                SendMessage(": " + user.UserName + "退出聊天！", 0);

            }
        }

        public void sendID1(int id)
        {
            lock (obj)
            {
                file_id = id;
            }

        }

        public void sendFile(FileInfo fileInfo)
        {
            Stream stream = fileInfo.OpenRead();
            dictionary.Add(fileInfo);
            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);
            ms.Position = 0;
            //ms.SetLength(stream.Length);
            stream.Flush();
            stream.Close();
            OperationContext context = null;

            string name1 = "";
            foreach (ServerUser user in users)
            {
                var userf = users.FirstOrDefault(i => i.ID == file_id);
                if (userf != null) name1 = userf.UserName;
                context = user.operationContext;
                context.GetCallbackChannel<IServerChatCallback>().MessageCallBack(name1 + "发送了一个文件 ,文件名: "+ fileInfo.Name +" 大小："+ ms.Length + "  Kb。");

            }
        }

        public void SendMessage(string message, int identificator)
        {
            foreach (var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var user = users.FirstOrDefault(i => i.ID == identificator);
                if (user != null)
                {
                    answer += ": " + user.UserName + " ";
                }
                answer += message;
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MessageCallBack(answer);
            }
        }

        public List<FileInfo> getFileList()
        {
            return dictionary;
        }



        public async void single(int i,string path)
        {
            OperationContext context = null;
            foreach(ServerUser user in users)
            {
                if (dowloaduserid == user.ID)
                {
                    context = user.operationContext;
                    break;
                }
            }
            await Task.Run(() => context.GetCallbackChannel<IServerChatCallback>().ReceiveFile(dictionary[i], path));
        }

        public void sendid(int id)
        {
            lock (obj)
            {
                dowloaduserid = id;
            }
            
        }
    }
}
