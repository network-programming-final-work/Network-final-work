using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;

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
    }
}
