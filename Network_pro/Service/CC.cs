using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service
{
    public class CC
    {
        //连接的用户，每个用户都对应一个GameService线程
        public static List<User> Users { get; set; }

    

    
        public static User[] players { get; set; }

        public static User GetUser(string userName)
        {
            User user = null;
            foreach (var v in Users)
            {
                if (v.UserName == userName)
                {
                    user = v;
                    break;
                }
            }
            return user;
        }
    }
}