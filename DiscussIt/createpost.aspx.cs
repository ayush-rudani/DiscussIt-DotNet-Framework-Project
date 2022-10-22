using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Runtime.Remoting.Contexts;

namespace DiscussIt
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (Session["role"].ToString() == "")
            {
                Response.Redirect("userlogin.aspx");
            }
        }

        protected void ButtonPost_Click(object sender, EventArgs e)
        {
            Addpost();
        }

        void Addpost()
        {
            string msg = "";
            if (!IsValidTitle(tbTitle.Text))
            {
                msg += "Title cannot be less than 3 characters or longer than 200!";
            }
            else if (!IsValidContent(tbContent.Text))
            {
                msg += "Content cannot be less than 5 characters or longer than 1500!";
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Post](posttitle,postcontent,postdate,userid) values(@posttitle,@postcontent,@postdate,@userid)", con);
                    cmd.Parameters.AddWithValue("@posttitle", tbTitle.Text);
                    cmd.Parameters.AddWithValue("@postcontent", tbContent.Text);
                    cmd.Parameters.AddWithValue("@postdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@userid", Session["userid"]);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Successfully Post');</script>");
                    Response.Redirect("mypost.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            if (msg != null)
            {
                lblError.Text = msg;
            }
        }
        private static bool IsValidTitle(string title)
        {
            if (title == null || title == "")
            {
                return false;
            }
            else if (title.Length < 3 || title.Length > 200)
            {
                return false;
            }
            return true;
        }
        private static bool IsValidContent(string content)
        {
            if (content == null || content == "")
            {
                return false;
            }
            else if (content.Length < 5 || content.Length > 1500)
            {
                return false;
            }
            return true;
        }
    }
}