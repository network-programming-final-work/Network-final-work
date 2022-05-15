using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ChatServer”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ChatServer.svc 或 ChatServer.svc.cs，然后开始调试。
    public class ChatServer : IChatServer
    {
        private bool _disposed;
        private readonly ServiceHost _host;

        public ChatServer(Uri baseAddress)
        {
            _host = new ServiceHost(typeof(ChatService), baseAddress);
            _host.Description.Behaviors.Add(new ServiceMetadataBehavior
            {
                HttpGetEnabled = true,
                MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }
            });
            _host.AddServiceEndpoint(typeof(IChatService), new WSDualHttpBinding(), "");
            _host.AddServiceEndpoint(
                  ServiceMetadataBehavior.MexContractName,
                  MetadataExchangeBindings.CreateMexHttpBinding(),
                  "mex"
                );
        }


        public void Start()
        {
            _host.Open();
        }

        public void Stop()
        {
            Dispose();
        }

        public IEnumerable<string> Endpoints { get { return _host.Description.Endpoints.Select(x => x.Address.ToString()); } }

        public void Dispose()
        {
            if (_disposed) return;
            _host.Close();
            _disposed = true;
        }
    }
}
