using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.IO;
using System.Net;
using System.Net.Mail;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace DiscussIt
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // sign up button click event
        protected void UserSignupBtn_Click(object sender, EventArgs e)
        {
            if (checkUserExists())
            {
                Response.Write("<script>alert('Member Already Exist with this Email ID, try other ID');</script>");
            }
            else
            {
                signUpNewUser();
                Response.Write("<script>alert('Sign Up Successful.');</script>");
                Response.Redirect("homepage.aspx");
            }
        }

        // user defined method
        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[User] where UserEmail='" + tbEmail.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void signUpNewUser()
        {
            string to = tbEmail.Text.Trim();
            string from = "amarklee777@gmail.com";
            MailMessage message = new MailMessage(from, to);
            string mailbody = "<h3>You have successfully registered for Discussit. Thank you for being a part of our community</h3>";

            message.Subject = "Registration Successful";
            message.Body = mailbody;
            message.IsBodyHtml = true;  
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("", "");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[User](username,useremail,userpassword,role) values(@username,@useremail,@userpassword,@role)", con);
                cmd.Parameters.AddWithValue("@username", tbName.Text.Trim());
                cmd.Parameters.AddWithValue("@useremail", tbEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@userpassword", tbPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@role", "user");
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * from [dbo].[User] where UserEmail='" + tbEmail.Text.Trim() + "' AND UserPassword='" + tbPassword.Text.Trim() + "';", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["userid"] = dr.GetValue(0).ToString();
                    }
                }
                con.Close();
                Session["username"] = tbName.Text.Trim();
                Session["email"] = tbEmail.Text.Trim();
                Session["role"] = "user";
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            try
            {
                client.Send(message);
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            
        }
    }
}