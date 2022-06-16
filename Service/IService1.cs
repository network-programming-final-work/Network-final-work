using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string MD5Encrypt(string str);
        [OperationContract]
        int Send(string email, string title,string text);
        [OperationContract]
        bool IsLogin(string name, string pwd);
        [OperationContract]
        bool AddUser(string name, string pwd,string email);
        [OperationContract]
        DataTable showInfo(int state);
        [OperationContract]
        bool ChangeState(int state,int id);
        [OperationContract]
        int getId();
        [OperationContract]
        bool Update(int infoId, string infoContent, int typeInfo, DateTime finishTime);
        [OperationContract]
        bool UpdatePwd(string name, string newpwd,string email);
        [OperationContract]
        bool Add(string infoContent, int typeInfo, DateTime finishTime, int infoState);
        [OperationContract]
        bool Delete(int infoId);
        [OperationContract]
        DataTable SearchInfo(string infoContent);
    }
}
