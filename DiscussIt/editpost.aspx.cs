using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace DiscussIt
{
    public partial class WebForm8 : System.Web.UI.Page
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
                int pid = Int32.Parse(Request.QueryString["id"]);
                if (!IsPostBack)
                {
                    LoadForm(pid);
                }
            }
        }
        void LoadForm(int pid)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[Post] where id="+ pid + ";", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       tbTitle.Text = dr.GetValue(1).ToString();
                       tbContent.Text = dr.GetValue(2).ToString();
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
        protected void BtnUpdatePost_Click(object sender, EventArgs e)
        {
            int pid = Int32.Parse(Request.QueryString["id"]);
            Updatepost(pid);
        }

        void Updatepost(int pid)
        {
            string msg = "";
            if (!IsValidTitle(tbTitle.Text))
            {
                msg += "Title cannot be less than 3 characters or longer than 200!";
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
                    SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[Post] where id="+ pid +";", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        SqlCommand cmd1 = new SqlCommand("UPDATE [dbo].[Post] SET PostTitle='" + tbTitle.Text + "',PostContent='" + tbContent.Text + "',postdate=@postdate WHERE id =" + pid + ";", con);
                        cmd1.Parameters.AddWithValue("@postdate", DateTime.Now);
                        cmd1.ExecuteNonQuery();
                        Response.Write("<script>alert('Post updated successfully.');</script>");
                        if (Session["role"].ToString() == "admin")
                        {
                            Response.Redirect("homepage.aspx");
                        }
                        else
                        {
                            Response.Redirect("mypost.aspx");
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
            else if (content.Length < 5 || content.Length > 300)
            {
                return false;
            }
            return true;
        }
    }
}