using System;
using System.Collections.Generic;
using System.IO;
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

        [OperationContract(IsOneWay = true)]
        void sendid(int id);

        [OperationContract(IsOneWay = true)]
        void sendID1(int id);

        [OperationContract(IsOneWay = true)]
        void sendFile(FileInfo fileInfo);

        [OperationContract(IsOneWay = true)]
        void single(int i,string path);

        [OperationContract]
        List<FileInfo> getFileList();
    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallBack(string message);

        [OperationContract(IsOneWay = true)]
        void ReceiveFile(FileInfo fileinfo,string path);
    }

}
