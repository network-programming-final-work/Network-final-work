using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ChatClient”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ChatClient.svc 或 ChatClient.svc.cs，然后开始调试。
    public class ChatClient : IChatClient<string>
    {
        private class ChatClientCallback : IChatCallback
        {
            private readonly ChatClient _client;

            public ChatClientCallback(ChatClient client)
            {
                _client = client;
            }

            public void NotifyBroadcast(string body)
            {
                if (_client.OnMessageRecieved != null)
                    _client.OnMessageRecieved(_client, body);
            }
        }

        private readonly ChatClient _client;

        public ChatClient(string address)
        {
            _client = new ChatClient(new InstanceContext(new ChatClientCallback(this)), new WSDualHttpBinding(), new EndpointAddress(address));
            _client.Register();
        }

        public void Send(string message)
        {
            _client.Send(message);
        }

        public void Dispose()
        {
            _client.UnRegister();
            _client.Close();
        }

        public event EventHandler<string> OnMessageRecieved;
    }
}
