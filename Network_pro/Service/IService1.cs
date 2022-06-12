using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int identificator);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, int identificator);
    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallBack(string message);
    }

}
