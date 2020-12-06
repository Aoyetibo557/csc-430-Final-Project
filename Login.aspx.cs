using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Routing;
using System.Web.Security;

namespace BMI_Web_API__ASP.NET_FRAMEWORK_
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|BmiDB.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        protected void loginMethod(object sender, EventArgs e)
        {
            using (SqlCommand loginCommand = new SqlCommand("SELECT COUNT(*) from userAccounts where username like @username AND userPassword like @userPwd", conn))
            {
                //To prevent SQL Injections
                SqlParameter username_param = loginCommand.Parameters.Add("@username", SqlDbType.Text, 100);
                username_param.Value = usernameTextBox.Text;

                SqlParameter pwd_param = loginCommand.Parameters.Add("@userPwd", SqlDbType.Text, 100);
                pwd_param.Value = passwordTextBox.Text;

                int userCount = (int)loginCommand.ExecuteScalar();

                //If the account exist userCount = 1;
                if (userCount > 0)
                {
                    loginalertBox.Text = "Account Exist in Database";
                    //Response.Redirect(GetRouteUrl("Dashboard.aspx", null));
                    Response.Redirect("Dashboard.aspx?UsernameValue=" + Server.UrlEncode(usernameTextBox.Text));
                }
                else if(userCount <= 0)
                {
                    loginalertBox.Text = "Account Doesn't Exist in Database";

                }

                //Clear Fields
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";

            }

        }

      
    }
}