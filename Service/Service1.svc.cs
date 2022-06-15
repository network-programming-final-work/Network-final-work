using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1 : IService1
    {
        public string name="";
        public static int userId = 0;
        string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public  int Send(string email, string text)//发送邮件
        {
            SmtpClient client = new SmtpClient("smtp.qq.com");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("1031563986@qq.com", "chifbuaewyfdbfbb");//"QQ邮箱", "授权码" //存入系统设置以便修改。
            MailAddress from = new MailAddress("1031563986@qq.com", "崔文帅", Encoding.UTF8);//初始化发件人
            MailAddress to = new MailAddress(email, "", Encoding.UTF8);//初始化收件人
            //设置邮件内容
            MailMessage message = new MailMessage(from, to);
            message.Subject = "找回密码";//邮件标题
            message.SubjectEncoding = Encoding.UTF8;//标题格式为UTF8
            message.Body = text;//邮件内容
            message.BodyEncoding = Encoding.UTF8;//内容格式为UTF8
            message.IsBodyHtml = true;

            //发送邮件
            try
            {
                client.Send(message);
                return 1;
                //MessageBox.Show("密码已发送到您的邮箱！");
            }
            catch (InvalidOperationException iex)
            {
                // MessageBox.Show(iex.Message);
                return 0;
            }
            
        }

        public bool UpdatePwd(string name, string newpwd, string email)//修改密码
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "update tbUsers set UserPwd='" + newpwd + "'  where UserName='" + name + "' and Email='" + email + "' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();//受影响的行数
                if (rows > 0)
                {
                    conn.Close();
                    conn.Dispose();
                    return true;
                }
                else
                {
                    conn.Close();
                    conn.Dispose();
                    return false;
                }
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                return false;
            }
        }

        public bool AddUser(string name, string pwd,string email)//注册
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "insert into tbUsers values('" + name + "','" + pwd + "','" + email + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();//受影响的行数
                if (rows>0)
                {
                    conn.Close();
                    conn.Dispose();
                    return true;
                }
                else
                {
                    conn.Close();
                    conn.Dispose();
                    return false;
                }
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                return false;
            }
        }

        public bool IsLogin(string name, string pwd)//登录
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "select * from tbUsers where UserName='" + name + "' and UserPwd='" + pwd + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        int id = read.GetInt32(0);
                        userId = id;
                        return true;
                    }
                }
                else
                {
                    read.Close();
                    conn.Close();
                    return false;
                }
                return false;
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                return false;
            }
        }

        public DataTable showInfo(int state)//显示详情
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "select a.*,b.TypeName from tbInfo a,tbInfoType b where UserId ='" + userId + "' and InfoState='"+state+ "' and a.InfoType=b.TypeId";
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds);
                dt = ds.Tables[0];
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                throw;
            }
            
        }

        public bool ChangeState(int state,int id)//更新状态
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "update tbInfo set InfoState='" + state + "' where InfoId='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                return false;
            }
            return true;
        }

        public int getId()
        {
            return userId;
        }

        public bool Update(int infoId, string infoContent, int typeInfo, DateTime finishTime)//更新
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "update tbInfo set InfoContent='" + infoContent + "',InfoType='" + typeInfo + "', FinishTime='" + finishTime + "' where InfoId='" + infoId + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    conn.Close();
                    conn.Dispose();
                    return true;
                }
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                return false;
            }
            return false;
        }

        public bool Add(string infoContent, int typeInfo, DateTime finishTime, int infoState)//新建任务
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "insert into tbInfo values('" + infoContent + "','" + typeInfo + "', '" + finishTime + "','" + userId + "','" + infoState + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    conn.Close();
                    conn.Dispose();
                    return true;
                }
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                return false;
            }
            return false;
        }

        public bool Delete(int infoId)//删除信息
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "delete from tbInfo where InfoId='"+infoId+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    conn.Close();
                    conn.Dispose();
                    return true;
                }
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                return false;
            }
            return false;
        }

        public DataTable SearchInfo(string infoContent)//模糊搜索
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = @"select a.*,b.TypeName from tbInfo a,tbInfoType b where UserId ='" + userId + "' and a.InfoType=b.TypeId and InfoContent like '%"+ infoContent + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds);
                dt = ds.Tables[0];
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                throw;
            }
        }


    }
}
