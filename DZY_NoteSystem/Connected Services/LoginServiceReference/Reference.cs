﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DZY_NoteSystem.LoginServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoginServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/MD5Encrypt", ReplyAction="http://tempuri.org/IService1/MD5EncryptResponse")]
        string MD5Encrypt(string str);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/MD5Encrypt", ReplyAction="http://tempuri.org/IService1/MD5EncryptResponse")]
        System.Threading.Tasks.Task<string> MD5EncryptAsync(string str);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Send", ReplyAction="http://tempuri.org/IService1/SendResponse")]
        int Send(string email, string title, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Send", ReplyAction="http://tempuri.org/IService1/SendResponse")]
        System.Threading.Tasks.Task<int> SendAsync(string email, string title, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IsLogin", ReplyAction="http://tempuri.org/IService1/IsLoginResponse")]
        bool IsLogin(string name, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IsLogin", ReplyAction="http://tempuri.org/IService1/IsLoginResponse")]
        System.Threading.Tasks.Task<bool> IsLoginAsync(string name, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddUser", ReplyAction="http://tempuri.org/IService1/AddUserResponse")]
        bool AddUser(string name, string pwd, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddUser", ReplyAction="http://tempuri.org/IService1/AddUserResponse")]
        System.Threading.Tasks.Task<bool> AddUserAsync(string name, string pwd, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/showInfo", ReplyAction="http://tempuri.org/IService1/showInfoResponse")]
        System.Data.DataTable showInfo(int state);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/showInfo", ReplyAction="http://tempuri.org/IService1/showInfoResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> showInfoAsync(int state);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ChangeState", ReplyAction="http://tempuri.org/IService1/ChangeStateResponse")]
        bool ChangeState(int state, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ChangeState", ReplyAction="http://tempuri.org/IService1/ChangeStateResponse")]
        System.Threading.Tasks.Task<bool> ChangeStateAsync(int state, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getId", ReplyAction="http://tempuri.org/IService1/getIdResponse")]
        int getId();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getId", ReplyAction="http://tempuri.org/IService1/getIdResponse")]
        System.Threading.Tasks.Task<int> getIdAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Update", ReplyAction="http://tempuri.org/IService1/UpdateResponse")]
        bool Update(int infoId, string infoContent, int typeInfo, System.DateTime finishTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Update", ReplyAction="http://tempuri.org/IService1/UpdateResponse")]
        System.Threading.Tasks.Task<bool> UpdateAsync(int infoId, string infoContent, int typeInfo, System.DateTime finishTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdatePwd", ReplyAction="http://tempuri.org/IService1/UpdatePwdResponse")]
        bool UpdatePwd(string name, string newpwd, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdatePwd", ReplyAction="http://tempuri.org/IService1/UpdatePwdResponse")]
        System.Threading.Tasks.Task<bool> UpdatePwdAsync(string name, string newpwd, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Add", ReplyAction="http://tempuri.org/IService1/AddResponse")]
        bool Add(string infoContent, int typeInfo, System.DateTime finishTime, int infoState);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Add", ReplyAction="http://tempuri.org/IService1/AddResponse")]
        System.Threading.Tasks.Task<bool> AddAsync(string infoContent, int typeInfo, System.DateTime finishTime, int infoState);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Delete", ReplyAction="http://tempuri.org/IService1/DeleteResponse")]
        bool Delete(int infoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Delete", ReplyAction="http://tempuri.org/IService1/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int infoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SearchInfo", ReplyAction="http://tempuri.org/IService1/SearchInfoResponse")]
        System.Data.DataTable SearchInfo(string infoContent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SearchInfo", ReplyAction="http://tempuri.org/IService1/SearchInfoResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> SearchInfoAsync(string infoContent);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : DZY_NoteSystem.LoginServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<DZY_NoteSystem.LoginServiceReference.IService1>, DZY_NoteSystem.LoginServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string MD5Encrypt(string str) {
            return base.Channel.MD5Encrypt(str);
        }
        
        public System.Threading.Tasks.Task<string> MD5EncryptAsync(string str) {
            return base.Channel.MD5EncryptAsync(str);
        }
        
        public int Send(string email, string title, string text) {
            return base.Channel.Send(email, title, text);
        }
        
        public System.Threading.Tasks.Task<int> SendAsync(string email, string title, string text) {
            return base.Channel.SendAsync(email, title, text);
        }
        
        public bool IsLogin(string name, string pwd) {
            return base.Channel.IsLogin(name, pwd);
        }
        
        public System.Threading.Tasks.Task<bool> IsLoginAsync(string name, string pwd) {
            return base.Channel.IsLoginAsync(name, pwd);
        }
        
        public bool AddUser(string name, string pwd, string email) {
            return base.Channel.AddUser(name, pwd, email);
        }
        
        public System.Threading.Tasks.Task<bool> AddUserAsync(string name, string pwd, string email) {
            return base.Channel.AddUserAsync(name, pwd, email);
        }
        
        public System.Data.DataTable showInfo(int state) {
            return base.Channel.showInfo(state);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> showInfoAsync(int state) {
            return base.Channel.showInfoAsync(state);
        }
        
        public bool ChangeState(int state, int id) {
            return base.Channel.ChangeState(state, id);
        }
        
        public System.Threading.Tasks.Task<bool> ChangeStateAsync(int state, int id) {
            return base.Channel.ChangeStateAsync(state, id);
        }
        
        public int getId() {
            return base.Channel.getId();
        }
        
        public System.Threading.Tasks.Task<int> getIdAsync() {
            return base.Channel.getIdAsync();
        }
        
        public bool Update(int infoId, string infoContent, int typeInfo, System.DateTime finishTime) {
            return base.Channel.Update(infoId, infoContent, typeInfo, finishTime);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAsync(int infoId, string infoContent, int typeInfo, System.DateTime finishTime) {
            return base.Channel.UpdateAsync(infoId, infoContent, typeInfo, finishTime);
        }
        
        public bool UpdatePwd(string name, string newpwd, string email) {
            return base.Channel.UpdatePwd(name, newpwd, email);
        }
        
        public System.Threading.Tasks.Task<bool> UpdatePwdAsync(string name, string newpwd, string email) {
            return base.Channel.UpdatePwdAsync(name, newpwd, email);
        }
        
        public bool Add(string infoContent, int typeInfo, System.DateTime finishTime, int infoState) {
            return base.Channel.Add(infoContent, typeInfo, finishTime, infoState);
        }
        
        public System.Threading.Tasks.Task<bool> AddAsync(string infoContent, int typeInfo, System.DateTime finishTime, int infoState) {
            return base.Channel.AddAsync(infoContent, typeInfo, finishTime, infoState);
        }
        
        public bool Delete(int infoId) {
            return base.Channel.Delete(infoId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(int infoId) {
            return base.Channel.DeleteAsync(infoId);
        }
        
        public System.Data.DataTable SearchInfo(string infoContent) {
            return base.Channel.SearchInfo(infoContent);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> SearchInfoAsync(string infoContent) {
            return base.Channel.SearchInfoAsync(infoContent);
        }
    }
}
