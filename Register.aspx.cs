using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BMI_Functions;

namespace BMI_Web_API__ASP.NET_FRAMEWORK_
{
    public partial class Register : System.Web.UI.Page
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

        protected void createNewAccount(object sender, EventArgs e)
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from userAccounts where emailAddress like @email AND username like @username", conn))
            {
               //To prevent SQL Injections
                SqlParameter emailParam = sqlCommand.Parameters.Add("@email", SqlDbType.Text, 100);
                emailParam.Value = emailAddressTextBox.Text;

                SqlParameter usernameParam = sqlCommand.Parameters.Add("@username", SqlDbType.Text, 100);
                usernameParam.Value = usernameTextBox.Text;

                int userCount = (int)sqlCommand.ExecuteScalar();
                
                //If the account exist userCount = 1;
                if(userCount > 0)
                {
                    alertLabel.Text = "Account Exist in Database";
                }
                else if(userCount <= 0)
                {
                    using (SqlCommand insertCommand = new SqlCommand("INSERT INTO userAccounts (firstname, lastname, emailAddress, username, userPassword, height, weight, BMI, BMI_goal, gender, friendList) VALUES (@firstname, @lastname, @email, @username, @password, @height, @weight, @bmi, @bmi_goal, @gender, 0)", conn))
                    {
                        //Sql Parameter takes in the (id, datatype and size)

                        SqlParameter firstNameParam = insertCommand.Parameters.Add("@firstname", SqlDbType.Text, 100);
                        firstNameParam.Value = firstnameTextBox.Text;

                        SqlParameter lastNameParam = insertCommand.Parameters.Add("@lastname", SqlDbType.Text, 100);
                        lastNameParam.Value = lastnameTextBox.Text;

                        SqlParameter email_param = insertCommand.Parameters.Add("@email", SqlDbType.Text, 100);
                        email_param.Value = emailAddressTextBox.Text;

                        SqlParameter userN_param = insertCommand.Parameters.Add("@username", SqlDbType.Text, 100);
                        userN_param.Value = usernameTextBox.Text;

                        SqlParameter pwd_param = insertCommand.Parameters.Add("@password", SqlDbType.Text, 100);
                        pwd_param.Value = passwordTextBox.Text;

                        SqlParameter height_param = insertCommand.Parameters.Add("@height", SqlDbType.Int, 100);
                        height_param.Value = heightTextBox.Text;

                        SqlParameter weight_param = insertCommand.Parameters.Add("@weight", SqlDbType.Int, 100);
                        weight_param.Value = weightTextBox.Text;
                       
                        SqlParameter bmiGoal_param = insertCommand.Parameters.Add("@bmi_goal", SqlDbType.Int, 100);
                        bmiGoal_param.Value = bmiGoalTextBox.Text;

                        SqlParameter bmi_param = insertCommand.Parameters.Add("@bmi", SqlDbType.Text, 100);
                        bmi_param.Value = calBmi();

                        SqlParameter gender_param = insertCommand.Parameters.Add("@gender", SqlDbType.Text, 100);
                        gender_param.Value = genderTextBox.Text;

                        insertCommand.Prepare();
                        insertCommand.ExecuteNonQuery();

                        alertLabel.Text = " User Table updated";

                        //Response.Redirect(GetRouteUrl("DashboardRoute", null));
                        Response.Redirect("Dashboard.aspx?UsernameValue=" + Server.UrlEncode(usernameTextBox.Text));
                    }                   
                }

            }
            //Clear the Text Fields after Update.
            firstnameTextBox.Text = "";
            lastnameTextBox.Text = "";
            emailAddressTextBox.Text = "";
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            heightTextBox.Text = "";
            weightTextBox.Text = "";
            bmiGoalTextBox.Text = "";
        }

        public double calBmi()
        {
            BmiFunctions testFunc = new BmiFunctions();
            int w = Convert.ToInt32(weightTextBox.Text);
            int h = Convert.ToInt32(heightTextBox.Text);
            double res = testFunc.CalculateBMI(w, h, 'm');
            return Math.Round(res, 2);
        }
    }
}