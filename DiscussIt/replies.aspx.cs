using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Xml.Linq;
using System.Threading;
using System.Security.Cryptography;

namespace DiscussIt
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public int rpid;
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = Int32.Parse(Request.QueryString["id"]);
            rpid = pid;
            Fillpost(pid);
            RepeterData(pid);
            ReplyRepeater.DataBind();
        }

        void Fillpost(int pid)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[Post] left join [dbo].[user] ON [dbo].[Post].userid=[dbo].[user].id where [dbo].[Post].id=" + pid + ";", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TitleLbl.Text = dr.GetValue(1).ToString();
                        ContentLbl.Text = dr.GetValue(2).ToString();
                        NameLbl.Text = dr.GetValue(6).ToString();
                        DateLbl.Text = dr.GetValue(3).ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('data not exist');</script>");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void RepeterData(int pid)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[Replies] inner join [dbo].[User] on [dbo].[Replies].userid = [dbo].[User].id inner join [dbo].[Post] on [dbo].[Replies].postid = [dbo].[post].id where [dbo].[Replies].Postid=" + pid+ ";", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ReplyRepeater.DataSource = ds;
                ReplyRepeater.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }   
        }

        protected void PostReplyBtn_Click(object sender, EventArgs e)
        {
            int eid = Int32.Parse(Request.QueryString["id"]);
            Replypost(eid);
        }
        void Replypost(int pid)
        {
            string msg = "";
            if (Session["role"].ToString() == "")
            {
                Response.Redirect("userlogin.aspx");
            }
            else if (!IsValidContent(tbContent.Text))
            {  
                msg += "Content cannot be less than 5 characters or longer than 300!";
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[Post] where id=" + pid + ";", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 1)
                {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO [dbo].[Replies](postid,userid,replycontent,postdate) values(@postid,@userid,@replycontent,@postdate)", con);
                        cmd2.Parameters.AddWithValue("@postid", pid);
                        cmd2.Parameters.AddWithValue("@userid", Session["userid"]);
                        cmd2.Parameters.AddWithValue("@replycontent", tbContent.Text);
                        cmd2.Parameters.AddWithValue("@postdate", DateTime.Now);
                        cmd2.ExecuteNonQuery();
                        //Response.Write("<script>alert('Reply successfully.');</script>");
                        tbContent.Text = "";
                        RepeterData(pid);
                        //Response.Redirect("mypost.aspx");
                        con.Close();
                    }
                    else
                    {
                        Response.Write("<script>alert('data not exist');</script>");
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            if (msg != null)
            {
                Label1.Text = msg;
            }

        }
        private static bool IsValidContent(string content)
        {
            if (content == null || content == "")
            {
                return false;
            }
            else if (content.Length < 5 || content.Length > 2000)
            {
                return false;
            }
            return true;
        }

        protected void DeleteLink_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            string id = lb.CommandArgument;
            int rid = Int32.Parse(id);

            Deletepost(rid);
        }
        void Deletepost(int rid)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[Replies] where id=" + rid + ";", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM [dbo].[Replies]  WHERE id =" + rid + ";", con);
                    cmd1.ExecuteNonQuery();
                    Response.Write("<script>alert('Post deleted successfully.');</script>");
                    RepeterData(rpid);
                }
                else
                {
                    Response.Write("<script>alert('data not exist');</script>");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
    }
}