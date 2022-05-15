using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract(CallbackContract = typeof(IChatCallback))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Register();
        [OperationContract(IsOneWay = true)]
        void Send(string body);
        [OperationContract(IsOneWay = true)]
        void UnRegister();
    }
    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyBroadcast(string body);
    }


}
