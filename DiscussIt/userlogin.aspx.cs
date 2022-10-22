using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace DiscussIt
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void UserLoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[User] where UserEmail='" + tbEmail.Text.Trim() + "' AND UserPassword='" + tbPassword.Text.Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Session["userid"] = dr.GetValue(0).ToString();
                        Session["username"] = dr.GetValue(1).ToString();
                        Session["email"] = tbEmail.Text.Trim();
                        if(dr.GetValue(4).ToString() == "admin")
                        {
                            Session["role"] = "admin";
                        }
                        else
                        {
                            Session["role"] = "user";
                        }
                        Response.Write("<script>alert('Successful login');</script>");
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
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

// for catch(SqlException ex)
/*StringBuilder errorMessages = new StringBuilder();
for (int i = 0; i < ex.Errors.Count; i++)
{
    errorMessages.Append("Index #" + i + "\n" +
        "Message: " + ex.Errors[i].Message + "\n" +
        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
        "Source: " + ex.Errors[i].Source + "\n" +
        "Procedure: " + ex.Errors[i].Procedure + "\n");
}
MessageBox.Show(errorMessages.ToString());*/