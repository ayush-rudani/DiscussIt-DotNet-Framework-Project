using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DiscussIt
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "")
            {
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                RepeterData();
                PostRepeater.DataBind();
            }
        }
        void RepeterData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[Post] inner join [dbo].[User] on [dbo].[Post].userid = [dbo].[User].id where [dbo].[Post].userid=" + Session["userid"] + ";", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (ds.Rows.Count == 0)
                {
                    datanotexist.Text = "You haven't Post anything yet";
                }
                PostRepeater.DataSource = ds;
                PostRepeater.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void EditLink_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            string id = lb.CommandArgument;
            Response.Redirect("editpost.aspx?id=" + id);

        }

        protected void ReplyLink_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            string id = lb.CommandArgument;
            Response.Redirect("replies.aspx?id=" + id);
        }

        protected void DeleteLink_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            string id = lb.CommandArgument;
            int eid = Int32.Parse(id);
            Deletepost(eid);
        }
        void Deletepost(int eid)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[Post] where id=" + eid + ";", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM [dbo].[Post]  WHERE id =" + eid + ";", con);
                    cmd1.ExecuteNonQuery();
                    Response.Write("<script>alert('Post deleted successfully.');</script>");
                    RepeterData();
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