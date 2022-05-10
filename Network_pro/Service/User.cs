using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service
{
    public class User
    {
        public string UserName { get; set; }

        /// <summary>与该用户通信的回调接口</summary>
        public readonly IService1Callback callback;
        public User(string userName, IService1Callback callback)
        {
            this.UserName = userName;
            this.callback = callback;
        }
    }
}