using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DiscussIt
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                if(!IsPostBack)
                {
                    lbluser.Text = Session["username"].ToString();
                    lbluseremail.Text = Session["email"].ToString();
                    tbName.Text = Session["username"].ToString();
                }
            }
        }

        protected void updateprofile_Click(object sender, EventArgs e)
        {
            Updateuserprofile();
        }
        void Updateuserprofile()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd1 = new SqlCommand("SELECT * from [dbo].[User] where id="+ Session["userid"] +" AND userpassword='" + oldpass.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[User] SET username='" + tbName.Text.Trim() + "',userpassword='" + newpass.Text.Trim() + "' WHERE id = " + Session["userid"] + ";", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session.Abandon();
                    Response.Write("<script>alert('Profile updated successfully.');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}