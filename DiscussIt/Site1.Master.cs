using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscussIt
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    UserLogin.Visible = true;
                    UserSignup.Visible = true;

                    Logout.Visible = false;
                    UserProfile.Visible = false;

                }
                else if (Session["role"].ToString() == "user" || Session["role"].ToString() == "admin")
                {   
                    UserLogin.Visible = false;
                    UserSignup.Visible = false;

                    Logout.Visible = true;
                    UserProfile.Visible = true;
                    UserProfile.Text = "Hello " + Session["username"].ToString();

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void UserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void UserSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void UserProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["role"] = "";
            Session["email"] = "";
            Session.Abandon();

            UserLogin.Visible = true;
            UserSignup.Visible = true;

            Logout.Visible = false;
            UserProfile.Visible = false;
            Response.Redirect("homepage.aspx");

        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }
    }
}